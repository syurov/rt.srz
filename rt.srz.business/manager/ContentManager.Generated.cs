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
    public partial interface IContentManager : IManagerBase<rt.srz.model.srz.Content, System.Guid>
    {
		// Get Methods
		IList<Content> GetByContentTypeId(System.Int32 concept);
		IList<Content> GetByInsuredPersonDataId(System.Guid insuredPersonDatum);
    
    }

    partial class ContentManager : ManagerBase<rt.srz.model.srz.Content, System.Guid>, IContentManager
    {
        #region Get Methods

		
		public IList<Content> GetByContentTypeId(System.Int32 concept)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Content));
			
			
			ICriteria conceptCriteria = criteria.CreateCriteria("Concept");
            conceptCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", concept));
			
			return criteria.List<Content>();
        }
		
		public IList<Content> GetByInsuredPersonDataId(System.Guid insuredPersonDatum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Content));
			
			
			ICriteria insuredPersonDatumCriteria = criteria.CreateCriteria("InsuredPersonDatum");
            insuredPersonDatumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", insuredPersonDatum));
			
			return criteria.List<Content>();
        }
		
		#endregion
    }
}