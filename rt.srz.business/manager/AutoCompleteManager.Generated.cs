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
    public partial interface IAutoCompleteManager : IManagerBase<rt.srz.model.srz.AutoComplete, System.Guid>
    {
		// Get Methods
		IList<AutoComplete> GetByGenderId(System.Int32 concept1);
		IList<AutoComplete> GetByTypeId(System.Int32 concept2);
		IList<AutoComplete> GetByName(System.String name);
    
    }

    partial class AutoCompleteManager : ManagerBase<rt.srz.model.srz.AutoComplete, System.Guid>, IAutoCompleteManager
    {
        #region Get Methods

		
		public IList<AutoComplete> GetByGenderId(System.Int32 concept1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(AutoComplete));
			
			
			ICriteria concept1Criteria = criteria.CreateCriteria("Concept1");
            concept1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", concept1));
			
			return criteria.List<AutoComplete>();
        }
		
		public IList<AutoComplete> GetByTypeId(System.Int32 concept2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(AutoComplete));
			
			
			ICriteria concept2Criteria = criteria.CreateCriteria("Concept2");
            concept2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", concept2));
			
			return criteria.List<AutoComplete>();
        }
		
		public IList<AutoComplete> GetByName(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(AutoComplete));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			return criteria.List<AutoComplete>();
        }
		
		#endregion
    }
}