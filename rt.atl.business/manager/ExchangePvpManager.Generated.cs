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
using rt.atl.model.atl;

namespace rt.atl.business.manager
{
    public partial interface IExchangePvpManager : IManagerBase<rt.atl.model.atl.ExchangePvp, int>
    {
		// Get Methods
		IList<ExchangePvp> GetByPrzBuffId(System.Int32 przbuf);
    
    }

    partial class ExchangePvpManager : ManagerBase<rt.atl.model.atl.ExchangePvp, int>, IExchangePvpManager
    {
        #region Get Methods

		
		public IList<ExchangePvp> GetByPrzBuffId(System.Int32 przbuf)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExchangePvp));
			
			
			ICriteria przbufCriteria = criteria.CreateCriteria("Przbuf");
            przbufCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", przbuf));
			
			return criteria.List<ExchangePvp>();
        }
		
		#endregion
    }
}