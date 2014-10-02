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
    public partial class ContentTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<IContentManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected rt.srz.business.manager.IContentManager manager;
        
        protected ISession session { get; set; }
		
		protected rt.srz.model.srz.Content CreateNewContent()
		{
			rt.srz.model.srz.Content entity = new rt.srz.model.srz.Content();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.NewGuid();
			
			entity.DocumentContent = new System.Byte[]{};
			entity.ChangeDate = System.DateTime.Now;
			entity.FileName = "Test Tes";
			entity.DocumentContent64 = "T";
			
			using(rt.srz.business.manager.IConceptManager conceptManager = ObjectFactory.GetInstance<IConceptManager>())
				{
				    var all = conceptManager.GetAll(1);
					if (all.Count > 0)
					{
						entity.ContentType = all[0];
					}
				}	
			
			using(rt.srz.business.manager.IInsuredPersonDatumManager insuredPersonDatumManager = ObjectFactory.GetInstance<IInsuredPersonDatumManager>())
				{
				    var all = insuredPersonDatumManager.GetAll(1);
					if (all.Count > 0)
					{
						entity.InsuredPersonData = all[0];
					}
				}	
			
			return entity;
		}
		protected rt.srz.model.srz.Content GetFirstContent()
        {
            IList<rt.srz.model.srz.Content> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.srz.model.srz.Content entity = CreateNewContent();
				
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
                rt.srz.model.srz.Content entityA = CreateNewContent();
				manager.Save(entityA);

                rt.srz.model.srz.Content entityB = manager.GetById(entityA.Id);

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
				rt.srz.model.srz.Content entityC = CreateNewContent();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.Content entityA = GetFirstContent();
				
				entityA.DocumentContent = new System.Byte[]{};
				
				manager.Update(entityA);

                rt.srz.model.srz.Content entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.DocumentContent, entityB.DocumentContent);
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
			    rt.srz.model.srz.Content entityC = CreateNewContent();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.srz.model.srz.Content entity = GetFirstContent();
				
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
