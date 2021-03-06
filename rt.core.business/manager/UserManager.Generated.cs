﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using rt.core.business.nhibernate;
using rt.core.model.core;

namespace rt.core.business.manager
{
    public partial interface IUserManager : IManagerBase<rt.core.model.core.User, System.Guid>
    {
		// Get Methods
		IList<User> GetByPointDistributionPolicyId(System.Guid pointDistributionPolicyId);
    
    }

    partial class UserManager : ManagerBase<rt.core.model.core.User, System.Guid>, IUserManager
    {
        #region Get Methods

		
		public IList<User> GetByPointDistributionPolicyId(System.Guid pointDistributionPolicyId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(User));
			
			
			ICriteria pointDistributionPolicyIdCriteria = criteria.CreateCriteria("PointDistributionPolicyId");
            pointDistributionPolicyIdCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", pointDistributionPolicyId));
			
			return criteria.List<User>();
        }
		
		#endregion
    }
}