﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignUsersToGroupControl.ascx.cs" company="Альянс">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.ui.pvp.Controls.Administration
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.UI;
  using System.Web.UI.WebControls;

  using rt.core.model.interfaces;
  using rt.srz.model.interfaces.service;

  using StructureMap;

  /// <summary>
  /// The assign users to group control.
  /// </summary>
  public partial class AssignUsersToGroupControl : UserControl
  {
    #region Fields

    /// <summary>
    /// The _group id.
    /// </summary>
    private Guid groupId;

    /// <summary>
    /// The _security service.
    /// </summary>
    private ISecurityService securityService;

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The save changes.
    /// </summary>
    public void SaveChanges()
    {
      SaveChanges(Guid.Empty);
    }

    /// <summary>
    /// The save changes.
    /// </summary>
    /// <param name="newGroupId">
    /// The new group id.
    /// </param>
    public void SaveChanges(Guid newGroupId)
    {
      var assignList = new List<Guid>();
      var detachList = new List<Guid>();
      foreach (ListItem item in cblUsers.Items)
      {
        if (item.Selected)
        {
          assignList.Add(Guid.Parse(item.Value));
        }
        else
        {
          detachList.Add(Guid.Parse(item.Value));
        }
      }

      securityService.AssignUsersToGroup(newGroupId != Guid.Empty ? newGroupId : groupId, assignList, detachList);
    }

    #endregion

    #region Methods

    /// <summary>
    /// The page_ init.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    protected void Page_Init(object sender, EventArgs e)
    {
      securityService = ObjectFactory.GetInstance<ISecurityService>();
    }

    /// <summary>
    /// The page_ load.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    protected void Page_Load(object sender, EventArgs e)
    {
      groupId = Request.QueryString["GroupId"] == null ? Guid.Empty : Guid.Parse(Request.QueryString["GroupId"]);

      if (!IsPostBack)
      {
        lbTitle.Text = string.Format("Добавление пользователей в группу: {0}", Request.QueryString["GroupName"]);

        var groupUsers = securityService.GetUsersByGroup(groupId);
        var allUsers = securityService.GetUsers();

        cblUsers.DataSource = allUsers;
        cblUsers.DataBind();
        foreach (ListItem item in cblUsers.Items)
        {
          if (groupUsers.Select(p => p.Id).Contains(Guid.Parse(item.Value)))
          {
            item.Selected = true;
          }
        }
      }
    }

    #endregion
  }
}