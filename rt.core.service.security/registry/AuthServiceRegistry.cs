﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthServiceRegistry.cs" company="Rintech">
//   Copyright (c) 2013. All rights reserved.
// </copyright>
// <summary>
//   регистр
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.core.service.security.registry
{
  #region references

  using rt.core.model.security;

  using StructureMap.Configuration.DSL;

  using rt.core.services.registry;

  #endregion

  /// <summary>
  ///   регистр
  /// </summary>
  public class AuthServiceRegistry : Registry ////ServiceRegistryBase<IAuthService, AuthService, AuthGate>
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthServiceRegistry"/> class. 
    ///   Конструктор
    /// </summary>
    public AuthServiceRegistry()
    {
      ForSingletonOf<IAuthService>().Use<AuthGate>();
    }

    #endregion
  }
}