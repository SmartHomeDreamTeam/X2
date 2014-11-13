using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using X2.Domain.Entity;
using X2.NHibernate;
using X2.Services.Runtime.Implementation.Repository;

namespace X2.Test.Service.Runtime.Implementation.Repository
{
    [TestFixture]
    public class QueryableRepositoryTests
    {
        private INHibernateService nHibernateService = new NHibernateService(new List<string>(){typeof(NHibernateService).Namespace}); 
        private QueryableRepository<UserInfor> repository; 

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            repository = new QueryableRepository<UserInfor>(nHibernateService);
        }

        [SetUp]
        public void Setup()
        {
            nHibernateService.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            nHibernateService.RollBack();
        }

        [Test]
        public void AddTest()
        {
            repository.SaveOrUpdate(new UserInfor(){Pin="5678", UserID = "UserId"});
        }

        [Test]
        public void UpdateTest()
        {
            var userInfor = repository.First();
            userInfor.UserID = "UpdateTest";
            repository.SaveOrUpdate(userInfor);
            
            nHibernateService.Flush();

            var result = repository.Where(x => x.UserID == "UpdateTest").ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].UserID, Is.EqualTo("UpdateTest"));
        }

        [Test]
        public void DeleteTest()
        {
            var userInfor = repository.First();
            repository.Delete(userInfor);

            nHibernateService.Flush();

            var result = repository.Get(userInfor.ID);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Top1Test()
        {
            var userInfor = repository.First();
            Assert.That(userInfor, Is.Not.Null);
        }

        [Test]
        public void Top10Test()
        {
            for (var i = 0; i < 100000; i++)
            {
                repository.SaveOrUpdate(new UserInfor(){Pin="5678", UserID = string.Format("UserId{0}", i)});
            }
            nHibernateService.Flush();
            var userInfors = repository.Take(10).ToList();
            Assert.That(userInfors.Count(), Is.EqualTo(10));
        }


        /// <summary>
        /// It looks like INNER JOIN
        /// </summary>
        [Test]
        public void MulitpleTableQuery()
        {
            var sessions =  new QueryableRepository<Session>(nHibernateService);
            var eventLogs = new QueryableRepository<EventLog>(nHibernateService);

            var query = from u in repository
                from s in sessions
                from e in eventLogs
                where u.ID == s.UserInforID && u.ID == e.UserInforID
                select
                    new
                    {
                        UserID = u.UserID,
                        SecreKey = s.SecretKey,
                        EventLogID = e.ID,
                        LogID = e.LogID,
                        Description = e.Description
                    };
            var result = query.ToList();
            Assert.That(result, Is.Not.Null);
        }
    }

    internal class QueryResult
    {
        public string UserID { get; set; }
        public string SecreKey { get; set; }
        public Guid EventLogID { get; set; }
        public Guid LogID { get; set; }
        public string Description { get; set; }
    }

}
