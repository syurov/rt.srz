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
using NHibernate.Context;
using NUnit.Framework;
using StructureMap;
using rt.core.business.nhibernate;
using rt.core.business.registry;
using rt.core.model;
using rt.srz.business.manager;
using rt.srz.model.srz;

namespace rt.srz.business.tests
{
	[TestFixture]
    public partial class MedicalInsuranceTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<IMedicalInsuranceManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
        }
        
        protected rt.srz.business.manager.IMedicalInsuranceManager manager;
        
        protected ISession session { get; set; }
		
		public static MedicalInsurance CreateNew (int depth = 0)
		{
			rt.srz.model.srz.MedicalInsurance entity = new rt.srz.model.srz.MedicalInsurance();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.NewGuid();
			
      entity.PolisSeria = "Test Test Test Te";
      entity.PolisNumber = "Test Test Test Test";
      entity.DateFrom = System.DateTime.Now;
      entity.DateTo = System.DateTime.Now;
      entity.IsActive = true;
      entity.DateStop = System.DateTime.Now;
      entity.Enp = "T";
      entity.StateDateFrom = System.DateTime.Now;
      entity.StateDateTo = System.DateTime.Now;
			
			using(rt.srz.business.manager.IInsuredPersonManager insuredPersonManager = ObjectFactory.GetInstance<IInsuredPersonManager>())
				{
           entity.InsuredPerson = null;
				}	
			
			using(rt.srz.business.manager.IConceptManager conceptManager = ObjectFactory.GetInstance<IConceptManager>())
				{
				    var all = conceptManager.GetAll(1);
            Concept entityRef = null;
					  if (all.Count > 0)
					  {
              entityRef = all[0];
					  }
          
					 if (entityRef == null && depth < 3)
           {
             depth++;
             entityRef = ConceptTests.CreateNew(depth);
             ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession().Save(entityRef);
           }
           
					 entity.PolisType = entityRef ;
				}	
			
			using(rt.srz.business.manager.IOrganisationManager organisationManager = ObjectFactory.GetInstance<IOrganisationManager>())
				{
				    var all = organisationManager.GetAll(1);
            Organisation entityRef = null;
					  if (all.Count > 0)
					  {
              entityRef = all[0];
					  }
          
					 if (entityRef == null && depth < 3)
           {
             depth++;
             entityRef = OrganisationTests.CreateNew(depth);
             ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession().Save(entityRef);
           }
           
					 entity.Smo = entityRef ;
				}	
			
			using(rt.srz.business.manager.IStatementManager statementManager = ObjectFactory.GetInstance<IStatementManager>())
				{
				    var all = statementManager.GetAll(1);
            Statement entityRef = null;
					  if (all.Count > 0)
					  {
              entityRef = all[0];
					  }
          
					 if (entityRef == null && depth < 3)
           {
             depth++;
             entityRef = StatementTests.CreateNew(depth);
             ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession().Save(entityRef);
           }
           
					 entity.Statement = entityRef ;
				}	
			
			return entity;
		}
		protected rt.srz.model.srz.MedicalInsurance GetFirstMedicalInsurance()
        {
            IList<rt.srz.model.srz.MedicalInsurance> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.srz.model.srz.MedicalInsurance entity = CreateNew();
				
                object result = manager.Save(entity);

                Assert.IsNotNull(result);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Read()
        {
            try
            {
                rt.srz.model.srz.MedicalInsurance entityA = CreateNew();
				manager.Save(entityA);

                rt.srz.model.srz.MedicalInsurance entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA, entityB);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
		[Test]
		public void Update()
        {
            try
            {
				rt.srz.model.srz.MedicalInsurance entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.MedicalInsurance entityA = GetFirstMedicalInsurance();
				
				entityA.PolisSeria = "Test Test Test Test Test Te";
				
				manager.Update(entityA);

                rt.srz.model.srz.MedicalInsurance entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.PolisSeria, entityB.PolisSeria);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Delete()
        {
            try
            {
			    rt.srz.model.srz.MedicalInsurance entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.MedicalInsurance entity = GetFirstMedicalInsurance();
				
                manager.Delete(entity);

                entity = manager.GetById(entity.Id);
                Assert.IsNull(entity);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
	}
}

