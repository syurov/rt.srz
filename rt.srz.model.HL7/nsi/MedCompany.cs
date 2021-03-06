// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MedCompany.cs" company="������">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The packet med company.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.model.Hl7.nsi
{
  using System;
  using System.Collections.Generic;
  using System.Xml.Schema;
  using System.Xml.Serialization;

  using rt.srz.model.Hl7.nsi.Mo;
  using rt.srz.model.Hl7.nsi.target;

  /// <summary>
  ///   The packet med company.
  /// </summary>
  [Serializable]
  [XmlType(AnonymousType = true)]
  public class MedCompany
  {
    #region Public Properties

    /// <summary>
    ///   The d_edit.
    /// </summary>
    [XmlElement("d_edit", Form = XmlSchemaForm.Unqualified)]
    public string DEdit { get; set; }

    /// <summary>
    ///   The doc.
    /// </summary>
    [XmlElement("doc", Form = XmlSchemaForm.Unqualified)]
    public MedCompanyDoc[] Doc { get; set; }

    /// <summary>
    ///   The e_mail.
    /// </summary>
    [XmlElement("e_mail", Form = XmlSchemaForm.Unqualified)]
    public string EMail { get; set; }

    /// <summary>
    ///   The fam_ruk.
    /// </summary>
    [XmlElement("fam_ruk", Form = XmlSchemaForm.Unqualified)]
    public string FamRuk { get; set; }

    /// <summary>
    ///   The fax.
    /// </summary>
    [XmlElement("fax", Form = XmlSchemaForm.Unqualified)]
    public string Fax { get; set; }

    /// <summary>
    ///   The im_ruk.
    /// </summary>
    [XmlElement("im_ruk", Form = XmlSchemaForm.Unqualified)]
    public string ImRuk { get; set; }

    /// <summary>
    ///   The inn.
    /// </summary>
    [XmlElement("inn", Form = XmlSchemaForm.Unqualified)]
    public string Inn { get; set; }

    /// <summary>
    ///   The jur address.
    /// </summary>
    [XmlElement("jurAddress", Form = XmlSchemaForm.Unqualified)]
    public CompanyJurAddress JurAddress { get; set; }

    /// <summary>
    ///   The kpp.
    /// </summary>
    [XmlElement("KPP", Form = XmlSchemaForm.Unqualified)]
    public string Kpp { get; set; }

    /// <summary>
    ///   The mcod.
    /// </summary>
    [XmlElement("mcod", Form = XmlSchemaForm.Unqualified)]
    public string Mcod { get; set; }

    /// <summary>
    ///   The med advice.
    /// </summary>
    [XmlElement("medAdvice", Form = XmlSchemaForm.Unqualified)]
    public List<CompanyAdvice> MedAdvice { get; set; }

    /// <summary>
    ///   The med include.
    /// </summary>
    [XmlElement("medInclude", Form = XmlSchemaForm.Unqualified)]
    public List<CompanyInclude> MedInclude { get; set; }

    /// <summary>
    ///   The nam_mok.
    /// </summary>
    [XmlElement(ElementName = "nam_mok", Form = XmlSchemaForm.Unqualified)]
    public string NamMok { get; set; }

    /// <summary>
    ///   The nam_mop.
    /// </summary>
    [XmlElement(ElementName = "nam_mop", Form = XmlSchemaForm.Unqualified)]
    public string NamMop { get; set; }

    /// <summary>
    ///   The ogrn.
    /// </summary>
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string Ogrn { get; set; }

    /// <summary>
    ///   The okopf.
    /// </summary>
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string Okopf { get; set; }

    /// <summary>
    ///   The org.
    /// </summary>
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string Org { get; set; }

    /// <summary>
    ///   The ot_ruk.
    /// </summary>
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string OtRuk { get; set; }

    /// <summary>
    ///   The phone.
    /// </summary>
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string Phone { get; set; }

    /// <summary>
    ///   The tf_okato.
    /// </summary>
    [XmlElement(ElementName = "tf_okato", Form = XmlSchemaForm.Unqualified)]
    public string TfOkato { get; set; }

    /// <summary>
    ///   The vedpri.
    /// </summary>
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string Vedpri { get; set; }

    /// <summary>
    ///   The www.
    /// </summary>
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string Www { get; set; }

    #endregion
  }
}