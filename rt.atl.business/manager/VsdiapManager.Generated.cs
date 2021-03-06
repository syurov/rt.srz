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
    public partial interface IVsdiapManager : IManagerBase<rt.atl.model.atl.Vsdiap, int>
    {
		// Get Methods
		IList<Vsdiap> GetBySMOID(System.Int32 smo);
		IList<Vsdiap> GetByDEDIT(System.DateTime dedit);
		IList<Vsdiap> GetByLO(System.Int32 lo);
    
    }

    partial class VsdiapManager : ManagerBase<rt.atl.model.atl.Vsdiap, int>, IVsdiapManager
    {
        #region Get Methods

		
		public IList<Vsdiap> GetBySMOID(System.Int32 smo)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Vsdiap));
			
			
			ICriteria smoCriteria = criteria.CreateCriteria("Smo");
            smoCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", smo));
			
			return criteria.List<Vsdiap>();
        }
		
		public IList<Vsdiap> GetByDEDIT(System.DateTime dedit)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Vsdiap));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Dedit", dedit));
			
			return criteria.List<Vsdiap>();
        }
		
		public IList<Vsdiap> GetByLO(System.Int32 lo)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Vsdiap));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Lo", lo));
			
			return criteria.List<Vsdiap>();
        }
		
		#endregion
    }
}