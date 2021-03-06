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
using rt.fias.business.manager;
using rt.fias.model.fias;

namespace rt.fias.business.tests
{
	[TestFixture]
    public partial class HouseIntervalTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Bootstrap();
            session = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
            CurrentSessionContext.Bind(session);
            manager = ObjectFactory.GetInstance<IHouseIntervalManager>();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
        }
        
        protected rt.fias.business.manager.IHouseIntervalManager manager;
        
        protected ISession session { get; set; }
		
		public static HouseInterval CreateNew (int depth = 0)
		{
			rt.fias.model.fias.HouseInterval entity = new rt.fias.model.fias.HouseInterval();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.NewGuid();
			
      entity.Postalcode = "Test";
      entity.Ifnsfl = "T";
      entity.Terrifnsfl = "T";
      entity.Ifnsul = "Tes";
      entity.Terrifnsul = "T";
      entity.Okato = "Test";
      entity.Oktmo = "Te";
      entity.Updatedate = System.DateTime.Now;
      entity.Intstart = 67;
      entity.Intend = 28;
      entity.Intguid = System.Guid.NewGuid();
      entity.Aoguid = System.Guid.NewGuid();
      entity.Startdate = System.DateTime.Now;
      entity.Enddate = System.DateTime.Now;
      entity.Normdoc = System.Guid.NewGuid();
      entity.Counter = 92;
			
			using(rt.fias.business.manager.IIntervalStatusManager intervalStatusManager = ObjectFactory.GetInstance<IIntervalStatusManager>())
				{
				    var all = intervalStatusManager.GetAll(1);
            IntervalStatus entityRef = null;
					  if (all.Count > 0)
					  {
              entityRef = all[0];
					  }
          
					 if (entityRef == null && depth < 3)
           {
             depth++;
             entityRef = IntervalStatusTests.CreateNew(depth);
             ObjectFactory.GetInstance<ISessionFactory>().GetCurrentSession().Save(entityRef);
           }
           
					 entity.INTSTATUS = entityRef ;
				}	
			
			return entity;
		}
		protected rt.fias.model.fias.HouseInterval GetFirstHouseInterval()
        {
            IList<rt.fias.model.fias.HouseInterval> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				rt.fias.model.fias.HouseInterval entity = CreateNew();
				
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
                rt.fias.model.fias.HouseInterval entityA = CreateNew();
				manager.Save(entityA);

                rt.fias.model.fias.HouseInterval entityB = manager.GetById(entityA.Id);

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
				rt.fias.model.fias.HouseInterval entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.fias.model.fias.HouseInterval entityA = GetFirstHouseInterval();
				
				entityA.Postalcode = "T";
				
				manager.Update(entityA);

                rt.fias.model.fias.HouseInterval entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.Postalcode, entityB.Postalcode);
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
			    rt.fias.model.fias.HouseInterval entityC = CreateNew();
				manager.Save(entityC);
				manager.Session.GetISession().Flush();
				manager.Session.GetISession().Clear();
			
                rt.fias.model.fias.HouseInterval entity = GetFirstHouseInterval();
				
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

