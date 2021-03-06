﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanId.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The plan id.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.person.target
{
  #region references

  using System;
  using System.Xml.Serialization;

  #endregion

  /// <summary>
  ///   The plan id.
  /// </summary>
  [Serializable]
  public class PlanId
  {
    #region Fields

    /// <summary>
    ///   The id.
    /// </summary>
    [XmlElement(ElementName = "CWE.1", Order = 1)]
    public string Id = "ОМС";

    /// <summary>
    ///   The oid.
    /// </summary>
    [XmlElement(ElementName = "CWE.3", Order = 3)]
    public string Oid = "1.2.643.2.40.5.100.72";

    #endregion
  }
}