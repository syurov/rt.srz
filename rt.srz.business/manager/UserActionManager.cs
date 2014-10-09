// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserActionManager.cs" company="��������">
//   Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary>
//   The UserActionManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace rt.srz.business.manager
{
  using System;
  using System.Linq;

  using NHibernate;

  using rt.core.business.security.interfaces;
  using rt.core.model.interfaces;
  using rt.srz.model.srz;

  using StructureMap;

  /// <summary>
  ///   The UserActionManager.
  /// </summary>
  public partial class UserActionManager
  {
    #region Public Methods and Operators

    /// <summary>
    /// The log access to personal data.
    /// </summary>
    /// <param name="statement">
    /// The statement.
    /// </param>
    /// <param name="Event">
    /// The event.
    /// </param>
    public void LogAccessToPersonalData(Statement statement, string Event)
    {
      var session = ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession();
      var user = ObjectFactory.GetInstance<ISecurityProvider>().GetCurrentUser();

      try
      {
        var userAction = new UserAction
                         {
                           UserId = user.Id, 
                           Statement = statement, 
                           Event =
                             session.QueryOver<Concept>()
                                    .Where(f => f.Name == Event || f.ShortName == Event)
                                    .List()
                                    .Single()
                         };
        session.SaveOrUpdate(userAction);
        session.Flush();
        session.Clear();
      }
      catch (Exception)
      {
      }
    }

    #endregion
  }
}