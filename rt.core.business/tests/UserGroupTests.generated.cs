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
using rt.core.business.manager;
using rt.core.model.core;

namespace rt.core.business.tests
{
	[TestFixture]
    public partial class UserGroupTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<IUserGroupManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected rt.core.business.manager.IUserGroupManager manager;
        
        protected ISession session { get; set; }
		
		public static UserGroup CreateNew (int depth = 0)
		{
			rt.core.model.core.UserGroup entity = new rt.core.model.core.UserGroup();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.NewGuid();
			
      entity.FakeField = 7;
			
			using(rt.core.business.manager.IGroupManager groupManager = ObjectFactory.GetInstance<IGroupManager>())
				{
           entity.Group = null;
				}	
			
			using(rt.core.business.manager.IUserManager userManager = ObjectFactory.GetInstance<IUserManager>())
				{
           entity.User = null;
				}	
			
			return entity;
		}
		protected rt.core.model.core.UserGroup GetFirstUserGroup()
        {
            IList<rt.core.model.core.UserGroup> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.core.model.core.UserGroup entity = CreateNew();
				
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
                rt.core.model.core.UserGroup entityA = CreateNew();
				manager.Save(entityA);

                rt.core.model.core.UserGroup entityB = manager.GetById(entityA.Id);

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
				rt.core.model.core.UserGroup entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.core.model.core.UserGroup entityA = GetFirstUserGroup();
				
				entityA.FakeField = 4;
				
				manager.Update(entityA);

                rt.core.model.core.UserGroup entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.FakeField, entityB.FakeField);
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
			    rt.core.model.core.UserGroup entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.core.model.core.UserGroup entity = GetFirstUserGroup();
				
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

