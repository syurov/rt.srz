﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QBP_ZP9.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The qb p_ z p 9.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.person.requests
{
  #region references

  using System;
  using System.Xml.Serialization;

  #endregion

  /// <summary>
  ///   The qb p_ z p 9.
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "QBP_ZP9", Namespace = "urn:hl7-org:v2xml")]
  public class QBP_ZP9 : BaseMessageTemplate
  {
    #region Fields

    /// <summary>
    ///   The qpd.
    /// </summary>
    [XmlElement(ElementName = "QPD", Order = 2)]
    public QPD_ZP9 Qpd = new QPD_ZP9();

    #endregion
  }
}