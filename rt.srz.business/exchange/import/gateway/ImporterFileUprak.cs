﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImporterFileUprak.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The importer file uprak.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.business.exchange.import.gateway
{
  using System;
  using System.IO;
  using System.Linq;

  using NHibernate;

  using NLog;

  using Quartz;

  using rt.core.business.server.exchange.import;
  using rt.srz.business.configuration.algorithms.serialization;
  using rt.srz.business.manager;
  using rt.srz.business.manager.cache;
  using rt.srz.model.Hl7.person;
  using rt.srz.model.srz;
  using rt.srz.model.srz.concepts;

  using StructureMap;

  /// <summary>
  ///   The importer file uprak.
  /// </summary>
  public class ImporterFileUprak : ImporterFile
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="ImporterFileUprak" /> class.
    /// </summary>
    public ImporterFileUprak()
      : base(ExchangeSubjectType.Erz)
    {
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// Применим ли импортер для данного типа сообщений?
    /// </summary>
    /// <param name="file">
    /// The file.
    /// </param>
    /// <returns>
    /// true, если применим, иначе false
    /// </returns>
    public override bool AppliesTo(FileInfo file)
    {
      return file.Extension == ".uprak1";
    }

    /// <summary>
    /// Обработка
    /// </summary>
    /// <param name="file">
    /// Путь к файлу загрузки
    /// </param>
    /// <param name="context">
    /// The context.
    /// </param>
    /// <returns>
    /// был ли обработан пакет
    /// </returns>
    public override bool Processing(FileInfo file, IJobExecutionContext context)
    {
      var logger = LogManager.GetCurrentClassLogger();

      // Попытка десериализации файла
      var personErp = new PersonErp();
      try
      {
        // Десериализация
        personErp = XmlSerializationHelper.Deserialize(file.FullName, personErp) as PersonErp;
      }
      catch (Exception ex)
      {
        // Ошибка десериализации либо создания бачта
        logger.Error(ex.Message, ex);
        throw;
      }

      // Получаем идентификатор батча
      var batchId = Guid.Empty;
      if (personErp != null && personErp.BeginPacket != null)
      {
        Guid.TryParse(personErp.BeginPacket.Identificator, out batchId);
      }

      if (batchId == Guid.Empty)
      {
        logger.Error("Не верный идентификатор пакета. Имя файла: " + file.FullName);
        return false;
      }

      var session = ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession();
      if (personErp == null || personErp.AckList == null)
      {
        return false;
      }

      // Парсим ошибки ФЛК от шлюза
      foreach (var ack in personErp.AckList)
      {
        var messageId = Guid.Empty;
        Guid.TryParse(ack.Msa.ReferenceIdentificator, out messageId);

        // Получаем ссылку на заявление
        var statement =
          session.QueryOver<Statement>()
                 .JoinQueryOver<MessageStatement>(s => s.MessageStatements)
                 .Where(ms => ms.Message.Id == messageId)
                 .List()
                 .FirstOrDefault();

        if (statement == null)
        {
          logger.Error("Отсутствует заявление");
          return false;
        }

        // Удаляем предыдущие ошибки
        var oldErrors =
          session.QueryOver<Error>()
                 .Where(x => x.Statement.Id == statement.Id && x.Application.Id == ExchangeSubjectType.Erz)
                 .List();
        foreach (var oldError in oldErrors)
        {
          session.Delete(oldError);
        }

        session.Flush();

        // Пишем ошибки в Errors
        var wasError = false;
        foreach (var uprErr in personErp.AckList.FirstOrDefault().ErrList)
        {
          // Пропускаем предупреждения
          if (uprErr.LevelSeriously != "E")
          {
            continue;
          }

          // Создаем запись в БД
          var error = new Error();
          error.Statement = statement;
          error.Application = ObjectFactory.GetInstance<IConceptCacheManager>().GetById(ExchangeSubjectType.Erz);
          error.Code = uprErr.ErrorCodeApp.MessageCode;
          error.Message1 = uprErr.ErrorCodeApp.MessageDescription;
          error.Repl = "Ошибки ФЛК шлюза РС";
          session.Save(error);

          // Взводим флаг ошибки
          wasError = true;
        }

        if (wasError)
        {
          // Меняем статус заявления на отклонено
          statement.Status = ObjectFactory.GetInstance<IConceptCacheManager>().GetById(StatusStatement.Cancelled);
          session.Save(statement);

          // Пишем ошибку в сообщение
          var message = ObjectFactory.GetInstance<IMessageManager>().GetById(messageId);
          if (message != null)
          {
            message.IsError = true;
            session.Save(message);
          }
        }

        // Чистим сессию
        session.Flush();
      }

      return true;
    }

    /// <summary>
    /// Отмена загрузки пакетов
    /// </summary>
    /// <param name="fileName">
    /// The file name.
    /// </param>
    public override void UndoBatches(string fileName)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Отмена загрузки пакета
    /// </summary>
    /// <param name="batch">
    /// The batch.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    protected override bool UndoBatch(Guid batch)
    {
      return true;
    }

    #endregion
  }
}