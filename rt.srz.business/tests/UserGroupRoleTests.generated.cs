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
    public partial class UserGroupRoleTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<IUserGroupRoleManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected rt.srz.business.manager.IUserGroupRoleManager manager;
        
        protected ISession session { get; set; }
		
		protected rt.srz.model.srz.UserGroupRole CreateNewUserGroupRole()
		{
			rt.srz.model.srz.UserGroupRole entity = new rt.srz.model.srz.UserGroupRole();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.NewGuid();
			
			
			using(rt.srz.business.manager.IGroupManager groupManager = ObjectFactory.GetInstance<IGroupManager>())
				{
				    var all = groupManager.GetAll(1);
					if (all.Count > 0)
					{
						entity.Group = all[0];
					}
				}	
			
			using(rt.srz.business.manager.IRoleManager roleManager = ObjectFactory.GetInstance<IRoleManager>())
				{
				    var all = roleManager.GetAll(1);
					if (all.Count > 0)
					{
						entity.Role = all[0];
					}
				}	
			
			using(rt.srz.business.manager.IUserManager userManager = ObjectFactory.GetInstance<IUserManager>())
				{
				    var all = userManager.GetAll(1);
					if (all.Count > 0)
					{
						entity.User = all[0];
					}
				}	
			
			return entity;
		}
		protected rt.srz.model.srz.UserGroupRole GetFirstUserGroupRole()
        {
            IList<rt.srz.model.srz.UserGroupRole> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.srz.model.srz.UserGroupRole entity = CreateNewUserGroupRole();
				
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
                rt.srz.model.srz.UserGroupRole entityA = CreateNewUserGroupRole();
				manager.Save(entityA);

                rt.srz.model.srz.UserGroupRole entityB = manager.GetById(entityA.Id);

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
			    rt.srz.model.srz.UserGroupRole entityC = CreateNewUserGroupRole();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.UserGroupRole entity = GetFirstUserGroupRole();
				
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
