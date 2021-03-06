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
    public partial class InsuredPersonDatumTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<IInsuredPersonDatumManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
        }
        
        protected rt.srz.business.manager.IInsuredPersonDatumManager manager;
        
        protected ISession session { get; set; }
		
		public static InsuredPersonDatum CreateNew (int depth = 0)
		{
			rt.srz.model.srz.InsuredPersonDatum entity = new rt.srz.model.srz.InsuredPersonDatum();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.NewGuid();
			
      entity.FirstName = "Test Test Test Test Tes";
      entity.LastName = "Te";
      entity.MiddleName = "Test Tes";
      entity.Birthday = System.DateTime.Now;
      entity.Birthday2 = "Tes";
      entity.BirthdayType = 40;
      entity.IsIncorrectDate = true;
      entity.IsNotGuru = true;
      entity.Snils = "Te";
      entity.Birthplace = "Test Test ";
      entity.IsNotCitizenship = true;
      entity.IsRefugee = true;
      entity.IsBadSnils = true;
      entity.NhFirstName = 25;
      entity.NhLastName = 91;
      entity.NhMiddleName = 94;
			
			using(rt.srz.business.manager.IConceptManager concept1Manager = ObjectFactory.GetInstance<IConceptManager>())
				{
           entity.Citizenship = null;
				}	
			
			using(rt.srz.business.manager.IConceptManager concept2Manager = ObjectFactory.GetInstance<IConceptManager>())
				{
           entity.Gender = null;
				}	
			
			using(rt.srz.business.manager.IConceptManager concept3Manager = ObjectFactory.GetInstance<IConceptManager>())
				{
           entity.Category = null;
				}	
			
			using(rt.srz.business.manager.IConceptManager concept4Manager = ObjectFactory.GetInstance<IConceptManager>())
				{
           entity.OldCountry = null;
				}	
			
			return entity;
		}
		protected rt.srz.model.srz.InsuredPersonDatum GetFirstInsuredPersonDatum()
        {
            IList<rt.srz.model.srz.InsuredPersonDatum> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.srz.model.srz.InsuredPersonDatum entity = CreateNew();
				
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
                rt.srz.model.srz.InsuredPersonDatum entityA = CreateNew();
				manager.Save(entityA);

                rt.srz.model.srz.InsuredPersonDatum entityB = manager.GetById(entityA.Id);

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
				rt.srz.model.srz.InsuredPersonDatum entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.InsuredPersonDatum entityA = GetFirstInsuredPersonDatum();
				
				entityA.FirstName = "Test Test Test T";
				
				manager.Update(entityA);

                rt.srz.model.srz.InsuredPersonDatum entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.FirstName, entityB.FirstName);
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
			    rt.srz.model.srz.InsuredPersonDatum entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.InsuredPersonDatum entity = GetFirstInsuredPersonDatum();
				
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

