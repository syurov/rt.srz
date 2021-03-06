﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Conflict.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   Конфликт
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.person.messages
{
  #region references

  using System;
  using System.Collections.Generic;
  using System.Xml.Serialization;

  using rt.srz.model.Hl7.person.target;

  #endregion

  /// <summary>
  ///   Конфликт
  /// </summary>
  [Serializable]
  public class Conflict : BaseMessageTemplate
  {
    #region Fields

    /// <summary>
    ///   Евн
    /// </summary>
    [XmlElement(ElementName = "EVN", Order = 2)]
    public Evn Evn;

    /// <summary>
    ///   Список пид
    /// </summary>
    [XmlElement(ElementName = "PID", Order = 3)]
    public List<MessagePid> PidList;

    #endregion
  }
}