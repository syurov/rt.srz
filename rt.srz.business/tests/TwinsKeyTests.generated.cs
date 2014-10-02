﻿using System;
using System.Collections.Generic;
using System.Text;
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
    public partial class TwinsKeyTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<ITwinsKeyManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected rt.srz.business.manager.ITwinsKeyManager manager;
        
        protected ISession session { get; set; }
		
		protected rt.srz.model.srz.TwinsKey CreateNewTwinsKey()
		{
			rt.srz.model.srz.TwinsKey entity = new rt.srz.model.srz.TwinsKey();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.NewGuid();
			
			
			using(rt.srz.business.manager.ISearchKeyTypeManager searchKeyTypeManager = ObjectFactory.GetInstance<ISearchKeyTypeManager>())
				{
				    var all = searchKeyTypeManager.GetAll(1);
					if (all.Count > 0)
					{
						entity.KeyType = all[0];
					}
				}	
			
			using(rt.srz.business.manager.ITwinManager twinManager = ObjectFactory.GetInstance<ITwinManager>())
				{
				    var all = twinManager.GetAll(1);
					if (all.Count > 0)
					{
						entity.Twin = all[0];
					}
				}	
			
			return entity;
		}
		protected rt.srz.model.srz.TwinsKey GetFirstTwinsKey()
        {
            IList<rt.srz.model.srz.TwinsKey> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.srz.model.srz.TwinsKey entity = CreateNewTwinsKey();
				
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
                rt.srz.model.srz.TwinsKey entityA = CreateNewTwinsKey();
				manager.Save(entityA);

                rt.srz.model.srz.TwinsKey entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA, entityB);
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
			    rt.srz.model.srz.TwinsKey entityC = CreateNewTwinsKey();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.TwinsKey entity = GetFirstTwinsKey();
				
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
