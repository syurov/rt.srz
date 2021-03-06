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
using rt.srz.model.srz;

namespace rt.srz.business.manager
{
    public partial interface IaddressManager : IManagerBase<rt.srz.model.srz.address, System.Guid>
    {
		// Get Methods
		IList<address> GetByRegulatoryId(System.Guid regulatoryId);
    
    }

    partial class addressManager : ManagerBase<rt.srz.model.srz.address, System.Guid>, IaddressManager
    {
        #region Get Methods

		
		public IList<address> GetByRegulatoryId(System.Guid regulatoryId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(address));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("RegulatoryId", regulatoryId));
			
			return criteria.List<address>();
        }
		
		#endregion
    }
}