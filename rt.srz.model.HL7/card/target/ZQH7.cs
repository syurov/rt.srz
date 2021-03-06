﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZQH7.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   ZQH7
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.card.target
{
  #region references

  using System;
  using System.Xml.Serialization;

  #endregion

  /// <summary>
  ///   ZQH7
  /// </summary>
  [Serializable]
  public class ZQH7
  {
    #region Public Properties

    /// <summary>
    ///   CNE1
    /// </summary>
    [XmlElement("CNE.1", Order = 1)]
    public byte CNE1 { get; set; }

    /// <summary>
    ///   CNE2
    /// </summary>
    [XmlElement("CNE.2", Order = 2)]
    public string CNE2 { get; set; }

    /// <summary>
    ///   CNE3
    /// </summary>
    [XmlElement("CNE.3", Order = 3)]
    public string CNE3 { get; set; }

    #endregion
  }
}