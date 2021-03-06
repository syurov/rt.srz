﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorLastName.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The validator last name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.business.manager.logicalcontrol.simple
{
  #region

  using NHibernate;

  using rt.srz.model.logicalcontrol.exceptions.step2;
  using rt.srz.model.Properties;

  using Resourcessrz = rt.srz.business.Properties.Resource;

  #endregion

  /// <summary>
  ///   The validator last name.
  /// </summary>
  public class ValidatorLastName : CheckTextProperty<FaultLastNameTextException>
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatorLastName"/> class.
    /// </summary>
    /// <param name="sessionFactory">
    /// The session factory.
    /// </param>
    public ValidatorLastName(ISessionFactory sessionFactory)
      : base(sessionFactory, x => x.InsuredPersonData.LastName, Resource.RegexFio)
    {
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets the caption.
    /// </summary>
    public override string Caption
    {
      get
      {
        return Resourcessrz.CaptionValidatorLastName;
      }
    }

    #endregion
  }
}