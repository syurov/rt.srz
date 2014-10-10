﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonErp.cs" company="РусБИТех">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The person erp.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.person
{
  #region references

  using System;
  using System.Xml.Serialization;

  #endregion

  /// <summary>
  ///   The person erp.
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "UPRMessageBatch", Namespace = "urn:Hl7-org:v2xml")]
  public class PersonErp : BasePersonTemplate
  {
  }
}