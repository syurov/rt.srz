﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExporterBatchTyped.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   Экспортер пакета
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.core.business.server.exchange.export
{
  #region

  using System;

  using Quartz;

  #endregion

  /// <summary>
  /// Экспортер пакета
  /// </summary>
  /// <typeparam name="TSerializeObject">
  /// Тип сериализуемого объекта
  /// </typeparam>
  /// <typeparam name="TNode">
  /// Тип ноды
  /// </typeparam>
  public abstract class ExporterBatchTyped<TSerializeObject, TNode> : ExporterBatch, 
                                                                    IExporterBatchTyped<TSerializeObject, TNode>
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ExporterBatchTyped{TSerializeObject,TNode}"/> class. 
    /// </summary>
    /// <param name="type">
    /// The type.
    /// </param>
    protected ExporterBatchTyped(Guid type)
      : base(type)
    {
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Объект текущего пакета
    /// </summary>
    public TSerializeObject SerializeObject { get; protected set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The add node.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    public virtual void AddNode(TNode node)
    {
      // Начинаем новый батч, в случае если к-во обработанных записей превысило допустимое значение
      if (Count >= MaxCountMessageInBatchSession)
      {
        BeginBatch();
      }
    }

    /// <summary>
    /// The bulk create and export.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    /// <param name="batchId">
    /// The batch Id.
    /// </param>
    public virtual void BulkCreateAndExport(IJobExecutionContext context, Guid batchId)
    {
    }

    #endregion
  }
}