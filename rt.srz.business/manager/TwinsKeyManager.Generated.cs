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
    public partial interface ITwinsKeyManager : IManagerBase<rt.srz.model.srz.TwinsKey, System.Guid>
    {
		// Get Methods
		IList<TwinsKey> GetByKeyTypeId(System.Guid searchKeyType);
		IList<TwinsKey> GetByTwinId(System.Guid twin);
    
    }

    partial class TwinsKeyManager : ManagerBase<rt.srz.model.srz.TwinsKey, System.Guid>, ITwinsKeyManager
    {
        #region Get Methods

		
		public IList<TwinsKey> GetByKeyTypeId(System.Guid searchKeyType)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(TwinsKey));
			
			
			ICriteria searchKeyTypeCriteria = criteria.CreateCriteria("SearchKeyType");
            searchKeyTypeCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", searchKeyType));
			
			return criteria.List<TwinsKey>();
        }
		
		public IList<TwinsKey> GetByTwinId(System.Guid twin)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(TwinsKey));
			
			
			ICriteria twinCriteria = criteria.CreateCriteria("Twin");
            twinCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", twin));
			
			return criteria.List<TwinsKey>();
        }
		
		#endregion
    }
}