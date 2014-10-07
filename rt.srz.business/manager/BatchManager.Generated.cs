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
    public partial interface IBatchManager : IManagerBase<rt.srz.model.srz.Batch, System.Guid>
    {
		// Get Methods
		IList<Batch> GetByCodeConfirmId(System.Int32 concept1);
		IList<Batch> GetBySubjectId(System.Int32 concept2);
		IList<Batch> GetByTypeId(System.Int32 concept3);
		IList<Batch> GetByPeriodId(System.Guid period);
		IList<Batch> GetByReceiverId(System.Guid organisation1);
		IList<Batch> GetBySenderId(System.Guid organisation2);
    
    }

    partial class BatchManager : ManagerBase<rt.srz.model.srz.Batch, System.Guid>, IBatchManager
    {
        #region Get Methods

		
		public IList<Batch> GetByCodeConfirmId(System.Int32 concept1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Batch));
			
			
			ICriteria concept1Criteria = criteria.CreateCriteria("Concept1");
            concept1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", concept1));
			
			return criteria.List<Batch>();
        }
		
		public IList<Batch> GetBySubjectId(System.Int32 concept2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Batch));
			
			
			ICriteria concept2Criteria = criteria.CreateCriteria("Concept2");
            concept2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", concept2));
			
			return criteria.List<Batch>();
        }
		
		public IList<Batch> GetByTypeId(System.Int32 concept3)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Batch));
			
			
			ICriteria concept3Criteria = criteria.CreateCriteria("Concept3");
            concept3Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", concept3));
			
			return criteria.List<Batch>();
        }
		
		public IList<Batch> GetByPeriodId(System.Guid period)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Batch));
			
			
			ICriteria periodCriteria = criteria.CreateCriteria("Period");
            periodCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", period));
			
			return criteria.List<Batch>();
        }
		
		public IList<Batch> GetByReceiverId(System.Guid organisation1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Batch));
			
			
			ICriteria organisation1Criteria = criteria.CreateCriteria("Organisation1");
            organisation1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", organisation1));
			
			return criteria.List<Batch>();
        }
		
		public IList<Batch> GetBySenderId(System.Guid organisation2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Batch));
			
			
			ICriteria organisation2Criteria = criteria.CreateCriteria("Organisation2");
            organisation2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", organisation2));
			
			return criteria.List<Batch>();
        }
		
		#endregion
    }
}