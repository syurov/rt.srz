﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthGate.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   Сервис авторизации
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.core.services
{
  #region references

  using System.ServiceModel;
  using System.ServiceModel.Activation;

  using rt.core.model.client;
  using rt.core.model.security;
  using rt.core.services.aspects;
  using rt.core.services.wcf;

  #endregion

  /// <summary>
  ///   Сервис авторизации
  /// </summary>
  [ErrorHandlingBehavior]
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, Namespace = "http://auth.ffoms.ru")]
  public class AuthGate : InterceptedBase, IAuthService
  {
    #region Fields

    /// <summary>
    ///   The service.
    /// </summary>
    private readonly IAuthService service = new AuthService();

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// Аутентификация по пользователю и паролю
    /// </summary>
    /// <param name="userName">
    /// Имя пользователя
    /// </param>
    /// <param name="password">
    /// Пароль
    /// </param>
    /// <returns>
    /// Результат аутентификации
    /// </returns>
    public AuthResponse Authenticate(string userName, string password)
    {
      return InvokeInterceptors(() => service.Authenticate(userName, password));
    }

    /// <summary>
    ///   The get auth response.
    /// </summary>
    /// <returns>
    ///   The <see cref="AuthResponse" />.
    /// </returns>
    public Token GetAuthToken()
    {
      return InvokeInterceptors(() => service.GetAuthToken());
    }

    #endregion
  }
}