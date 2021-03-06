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
    public partial interface IpersonManager : IManagerBase<rt.atl.model.atl.person, int>
    {
		// Get Methods
		IList<person> GetByZID(System.Int32 zid);
		IList<person> GetByBIRTH_OKSM(System.String birthOksm);
		IList<person> GetByCN(System.String cn);
		IList<person> GetByDEDIT(System.DateTime dedit);
		IList<person> GetByDEL(System.Boolean del);
		IList<person> GetByDERP(System.DateTime derp);
		IList<person> GetByDOCTP(System.String doctp);
		IList<person> GetByNPOLSPOL(System.String npol, System.String spol);
		IList<person> GetByENP(System.String enp);
		IList<person> GetByFAME(System.String fame);
		IList<person> GetByFAMIMOTDR(System.String fam, System.String im, System.String ot, System.DateTime dr);
		IList<person> GetByIME(System.String ime);
		IList<person> GetByLPU(System.String lpu);
		IList<person> GetByOPSMO(System.Int32 opsmo);
		IList<person> GetByOTE(System.String ote);
		IList<person> GetByOTHER(System.Boolean other);
		IList<person> GetByPID(System.Int32 pid);
		IList<person> GetByPRN(System.String prn);
		IList<person> GetByQ(System.String q);
		IList<person> GetByRDOCTP(System.String rdoctp);
		IList<person> GetByRN(System.String rn);
		IList<person> GetBySENP(System.String senp);
		IList<person> GetBySS(System.String ss);
		IList<person> GetByTAKT(System.String takt);
		IList<person> GetByDOCNDOCS(System.String docn, System.String docs);
		IList<person> GetByUNEMP(System.Boolean unemp);
		IList<person> GetByW(System.Int32 w);
		IList<person> GetByZDOCTP(System.String zdoctp);
		IList<person> GetByZENP(System.String zenp);
		IList<person> GetByZT(System.Int32 zt);
    
    }

    partial class personManager : ManagerBase<rt.atl.model.atl.person, int>, IpersonManager
    {
        #region Get Methods

		
		public IList<person> GetByZID(System.Int32 zid)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			ICriteria zidCriteria = criteria.CreateCriteria("Zid");
            zidCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", zid));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByBIRTH_OKSM(System.String birthOksm)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("BirthOksm", birthOksm));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByCN(System.String cn)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Cn", cn));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByDEDIT(System.DateTime dedit)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Dedit", dedit));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByDEL(System.Boolean del)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Del", del));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByDERP(System.DateTime derp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Derp", derp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByDOCTP(System.String doctp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Doctp", doctp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByNPOLSPOL(System.String npol, System.String spol)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Npol", npol));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Spol", spol));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByENP(System.String enp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Enp", enp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByFAME(System.String fame)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Fame", fame));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByFAMIMOTDR(System.String fam, System.String im, System.String ot, System.DateTime dr)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Fam", fam));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Im", im));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Ot", ot));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Dr", dr));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByIME(System.String ime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Ime", ime));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByLPU(System.String lpu)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Lpu", lpu));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByOPSMO(System.Int32 opsmo)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Opsmo", opsmo));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByOTE(System.String ote)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Ote", ote));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByOTHER(System.Boolean other)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Other", other));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByPID(System.Int32 pid)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Pid", pid));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByPRN(System.String prn)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Prn", prn));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByQ(System.String q)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Q", q));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByRDOCTP(System.String rdoctp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Rdoctp", rdoctp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByRN(System.String rn)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Rn", rn));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetBySENP(System.String senp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Senp", senp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetBySS(System.String ss)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Ss", ss));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByTAKT(System.String takt)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Takt", takt));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByDOCNDOCS(System.String docn, System.String docs)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Docn", docn));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Docs", docs));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByUNEMP(System.Boolean unemp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Unemp", unemp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByW(System.Int32 w)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("W", w));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByZDOCTP(System.String zdoctp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Zdoctp", zdoctp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByZENP(System.String zenp)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Zenp", zenp));
			
			return criteria.List<person>();
        }
		
		public IList<person> GetByZT(System.Int32 zt)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(person));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Zt", zt));
			
			return criteria.List<person>();
        }
		
		#endregion
    }
}