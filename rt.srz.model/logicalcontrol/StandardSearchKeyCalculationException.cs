﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandardSearchKeyCalculationException.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The standard search key calculation exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.logicalcontrol
{
  using System;
  using System.Runtime.Serialization;

  /// <summary>
  /// The standard search key calculation exception.
  /// </summary>
  [Serializable]
  public class StandardSearchKeyCalculationException : LogicalControlException
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="StandardSearchKeyCalculationException"/> class. 
    ///   Initializes a new instance of the <see cref="FaultDubleException"/> class.
    /// </summary>
    public StandardSearchKeyCalculationException()
      : base(new ExceptionInfo("99"), "Ошибка расчета стандартных ключей")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StandardSearchKeyCalculationException"/> class.
    /// </summary>
    /// <param name="info">
    /// The info.
    /// </param>
    /// <param name="context">
    /// The context.
    /// </param>
    protected StandardSearchKeyCalculationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// The step.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    protected override int Step()
    {
      return 6;
    }

    #endregion
  }
}