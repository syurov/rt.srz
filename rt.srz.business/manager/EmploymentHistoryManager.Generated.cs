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
    public partial interface IEmploymentHistoryManager : IManagerBase<rt.srz.model.srz.EmploymentHistory, System.Guid>
    {
		// Get Methods
		IList<EmploymentHistory> GetBySourceTypeId(System.Int32 concept);
		IList<EmploymentHistory> GetByInsuredPersonId(System.Guid insuredPerson);
		IList<EmploymentHistory> GetByPeriodId(System.Guid period);
		IList<EmploymentHistory> GetByQueryResponseId(System.Guid queryResponse);
    
    }

    partial class EmploymentHistoryManager : ManagerBase<rt.srz.model.srz.EmploymentHistory, System.Guid>, IEmploymentHistoryManager
    {
        #region Get Methods

		
		public IList<EmploymentHistory> GetBySourceTypeId(System.Int32 concept)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(EmploymentHistory));
			
			
			ICriteria conceptCriteria = criteria.CreateCriteria("Concept");
            conceptCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", concept));
			
			return criteria.List<EmploymentHistory>();
        }
		
		public IList<EmploymentHistory> GetByInsuredPersonId(System.Guid insuredPerson)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(EmploymentHistory));
			
			
			ICriteria insuredPersonCriteria = criteria.CreateCriteria("InsuredPerson");
            insuredPersonCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", insuredPerson));
			
			return criteria.List<EmploymentHistory>();
        }
		
		public IList<EmploymentHistory> GetByPeriodId(System.Guid period)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(EmploymentHistory));
			
			
			ICriteria periodCriteria = criteria.CreateCriteria("Period");
            periodCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", period));
			
			return criteria.List<EmploymentHistory>();
        }
		
		public IList<EmploymentHistory> GetByQueryResponseId(System.Guid queryResponse)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(EmploymentHistory));
			
			
			ICriteria queryResponseCriteria = criteria.CreateCriteria("QueryResponse");
            queryResponseCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", queryResponse));
			
			return criteria.List<EmploymentHistory>();
        }
		
		#endregion
    }
}