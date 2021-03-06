﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateRange.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The date range.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.person.target
{
  #region references

  using System;
  using System.Xml.Serialization;

  #endregion

  /// <summary>
  ///   The date range.
  /// </summary>
  [Serializable]
  public class DateRange
  {
    #region Fields

    /// <summary>
    ///   The date from.
    /// </summary>
    [XmlElement(ElementName = "DR.1", Order = 1)]
    public string DateFrom;

    /// <summary>
    ///   The date to.
    /// </summary>
    [XmlElement(ElementName = "DR.2", Order = 2)]
    public string DateTo;

    #endregion
  }
}