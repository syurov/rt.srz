﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaultSnilsExistsException.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The fault snils exists exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.logicalcontrol.exceptions.step2
{
  #region

  using System;
  using System.Runtime.Serialization;

  using rt.srz.model.Properties;

  #endregion

  /// <summary>
  ///   The fault snils exists exception.
  /// </summary>
  [Serializable]
  public class FaultSnilsExistsException : FaultStep2
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="FaultSnilsExistsException" /> class.
    /// </summary>
    public FaultSnilsExistsException()
      : base(new ExceptionInfo(Resource.FaultSnilsExistsExceptionCode), Resource.FaultSnilsExistsExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FaultSnilsExistsException"/> class.
    /// </summary>
    /// <param name="info">
    /// The info.
    /// </param>
    /// <param name="context">
    /// The context.
    /// </param>
    protected FaultSnilsExistsException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    #endregion
  }
}