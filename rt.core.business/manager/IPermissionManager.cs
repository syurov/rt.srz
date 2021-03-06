// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPermissionManager.cs" company="������">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The interface PermissionManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.core.business.manager
{
  using System;
  using System.Collections.Generic;

  using rt.core.model.core;

  /// <summary>
  ///   The interface PermissionManager.
  /// </summary>
  public partial interface IPermissionManager
  {
    #region Public Methods and Operators

    /// <summary>
    /// �������� ����������
    /// </summary>
    /// <param name="id">
    /// </param>
    void DeletePermission(Guid id);

    /// <summary>
    /// ��������� ���� �� � ���� ���������� � ��������� �� � �����
    /// </summary>
    /// <param name="permissionId">
    /// </param>
    /// <param name="code">
    /// </param>
    /// <returns>
    /// The <see cref="bool"/> .
    /// </returns>
    bool ExistsPermissionCode(Guid permissionId, int code);

    /// <summary>
    /// �������� ������ ���������� �������� ������� ���������� � ���������� ��������
    /// </summary>
    /// <param name="contains">
    /// </param>
    /// <returns>
    /// The <see cref="IList"/> .
    /// </returns>
    IList<Permission> GetPermissionsByNameContains(string contains);

    #endregion
  }
}