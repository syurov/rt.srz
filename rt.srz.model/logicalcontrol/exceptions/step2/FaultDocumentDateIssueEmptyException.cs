// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaultDocumentDateIssueEmptyException.cs" company="������">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The fault snils exception.
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
  ///   The fault snils exception.
  /// </summary>
  [Serializable]
  public class FaultDocumentDateIssueEmptyException : FaultStep2
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="FaultDocumentDateIssueEmptyException" /> class.
    /// </summary>
    public FaultDocumentDateIssueEmptyException()
      : base(
        new ExceptionInfo(Resource.FaultDocumentDateIssueEmptyExceptionCode), 
        Resource.FaultDocumentDateIssueEmptyExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FaultDocumentDateIssueEmptyException"/> class.
    /// </summary>
    /// <param name="info">
    /// The info.
    /// </param>
    /// <param name="context">
    /// The context.
    /// </param>
    protected FaultDocumentDateIssueEmptyException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    #endregion
  }
}