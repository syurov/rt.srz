﻿using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Context;
using NUnit.Framework;
using StructureMap;
using rt.core.business.nhibernate;
using rt.core.business.registry;
using rt.core.model;
using rt.atl.business.manager;
using rt.atl.model.atl;

namespace rt.atl.business.tests
{
	[TestFixture]
    public partial class SmoTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<ISmoManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
        }
        
        protected rt.atl.business.manager.ISmoManager manager;
        
        protected ISession session { get; set; }
		
		public static Smo CreateNew (int depth = 0)
		{
			rt.atl.model.atl.Smo entity = new rt.atl.model.atl.Smo();
			
			
      entity.Dedit = System.DateTime.Now;
      entity.Caption = "Test Test ";
      entity.Code = "123";
      entity.Fullname = "Test Test ";
      entity.Ogrn = "Test ";
      entity.Bossname = "Tes";
      entity.Buhname = "Tes";
      entity.Email = "Test Test Test Test Test Test Test Test Tes";
      entity.Tel1 = "Test Test ";
      entity.Tel2 = "Test Test ";
      entity.Addr = "Test Test ";
      entity.Okato = "T";
      entity.Extcode = "T";
      entity.De = System.DateTime.Now;
      entity.Db = System.DateTime.Now;
      entity.Prid = 16;
			
			return entity;
		}
		protected rt.atl.model.atl.Smo GetFirstSmo()
        {
            IList<rt.atl.model.atl.Smo> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.atl.model.atl.Smo entity = CreateNew();
				
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
                rt.atl.model.atl.Smo entityA = CreateNew();
				manager.Save(entityA);

                rt.atl.model.atl.Smo entityB = manager.GetById(entityA.Id);

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
				rt.atl.model.atl.Smo entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.atl.model.atl.Smo entityA = GetFirstSmo();
				
				entityA.Dedit = System.DateTime.Now;
				
				manager.Update(entityA);

                rt.atl.model.atl.Smo entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.Dedit, entityB.Dedit);
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
			    rt.atl.model.atl.Smo entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.atl.model.atl.Smo entity = GetFirstSmo();
				
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

