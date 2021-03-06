﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TwinsJob.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The calculating job.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.business.server
{
  #region

  using Quartz;

  using rt.core.business.quartz;
  using rt.srz.business.manager;

  using StructureMap;

  #endregion

  /// <summary>
  ///   The calculating job.
  /// </summary>
  public class TwinsJob : JobBase
  {
    #region Fields

    /// <summary>
    ///   The lock object.
    /// </summary>
    private string lockObject = "lock";

    #endregion

    #region Properties

    /// <summary>
    ///   Gets the lock object.
    /// </summary>
    protected string LockObject
    {
      get
      {
        return lockObject;
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// The execute impl.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    protected override void ExecuteImpl(IJobExecutionContext context)
    {
      lock (LockObject)
      {
        // Ставим тригер на паузу, чтобы не плодить потоков, которые выпадут в ожидание по lock
        context.Scheduler.PauseTrigger(context.Trigger.Key);
        try
        {
          var executeStoredManager = ObjectFactory.GetInstance<IExecuteStoredManager>();
          executeStoredManager.FindTwins();
        }
        finally
        {
          context.Scheduler.ResumeTrigger(context.Trigger.Key);
        }
      }
    }

    #endregion
  }
}