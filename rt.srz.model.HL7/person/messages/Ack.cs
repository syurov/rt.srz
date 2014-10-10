﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ack.cs" company="РусБИТех">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The ack.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.person.messages
{
  #region references

  using System;
  using System.Xml.Serialization;

  #endregion

  /// <summary>
  ///   The ack.
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "ACK", Namespace = "urn:Hl7-org:v2xml")]
  public class Ack : BaseAnswerMessageTemplate
  {
  }
}