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
    public partial class UechiststatusTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<IUechiststatusManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
        }
        
        protected rt.atl.business.manager.IUechiststatusManager manager;
        
        protected ISession session { get; set; }
		
		public static Uechiststatus CreateNew (int depth = 0)
		{
			rt.atl.model.atl.Uechiststatus entity = new rt.atl.model.atl.Uechiststatus();
			
			
      entity.Dt = System.DateTime.Now;
			entity.Uecstatus = null;
			entity.Ufile = null;
			
			using(rt.atl.business.manager.IUecManager uecManager = ObjectFactory.GetInstance<IUecManager>())
				{
           entity.UEC = null;
				}	
			
			return entity;
		}
		protected rt.atl.model.atl.Uechiststatus GetFirstUechiststatus()
        {
            IList<rt.atl.model.atl.Uechiststatus> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.atl.model.atl.Uechiststatus entity = CreateNew();
				
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
                rt.atl.model.atl.Uechiststatus entityA = CreateNew();
				manager.Save(entityA);

                rt.atl.model.atl.Uechiststatus entityB = manager.GetById(entityA.Id);

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
				rt.atl.model.atl.Uechiststatus entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.atl.model.atl.Uechiststatus entityA = GetFirstUechiststatus();
				
				entityA.Dt = System.DateTime.Now;
				
				manager.Update(entityA);

                rt.atl.model.atl.Uechiststatus entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.Dt, entityB.Dt);
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
			    rt.atl.model.atl.Uechiststatus entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.atl.model.atl.Uechiststatus entity = GetFirstUechiststatus();
				
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

