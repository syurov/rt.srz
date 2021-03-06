﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobBase.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The job base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.core.business.quartz
{
  using System;

  using NHibernate;
  using NHibernate.Context;

  using NLog;

  using Quartz;

  using StructureMap;

  /// <summary>
  ///   The job base.
  /// </summary>
  public abstract class JobBase : IJob, IInterruptableJob
  {
    #region Static Fields

    /// <summary>
    ///   Логгер
    /// </summary>
    protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The execute.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    public void Execute(IJobExecutionContext context)
    {
      try
      {
        BeginExecute(context);
        ExecuteImpl(context);
        EndExecute(context);
      }
      catch (Exception exception)
      {
        LogManager.GetCurrentClassLogger()
                  .Fatal("Не обработаная ошибка запуска или выполнения задачи IJob", exception);
      }
    }

    /// <summary>
    ///   Запрос на прерывание работы
    /// </summary>
    public virtual void Interrupt()
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// The begin execute.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    protected virtual void BeginExecute(IJobExecutionContext context)
    {
      logger.Info(
                  "Старт задачи '{0}.{1}'. InstanceID = {2}", 
                  context.JobDetail.Key.Group, 
                  context.JobDetail.Key.Name, 
                  context.JobInstance.GetHashCode());
      foreach (var pair in context.JobDetail.JobDataMap)
      {
        logger.Info(
                    string.Format(
                                  "'{0}.{1}'. InstanceID = {2}. {3} = {4}", 
                                  context.JobDetail.Key.Group, 
                                  context.JobDetail.Key.Name, 
                                  context.JobInstance.GetHashCode()), 
                    pair.Key, 
                    pair.Value);
      }

      // Открываем сессию хибера и биндим ее с 
      var session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
      CurrentSessionContext.Bind(session);
    }

    /// <summary>
    /// The end execute.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    protected virtual void EndExecute(IJobExecutionContext context)
    {
      // Закрываем сессию хибернейта
      var sessionFactory = ObjectFactory.GetInstance<ISessionFactory>();
      var session = CurrentSessionContext.Unbind(sessionFactory);

      if (session != null)
      {
        if (session.Transaction != null && session.Transaction.IsActive)
        {
          session.Transaction.Dispose();
        }

        session.Flush();
        session.Clear();
        session.Close();
        session.Dispose();
      }

      logger.Info(
                  "Конец выполнения задачи '{0}.{1}'. InstanceID = {2}", 
                  context.JobDetail.Key.Group, 
                  context.JobDetail.Key.Name, 
                  context.JobInstance.GetHashCode());
    }

    /// <summary>
    /// The execute impl.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    protected abstract void ExecuteImpl(IJobExecutionContext context);

    #endregion
  }
}