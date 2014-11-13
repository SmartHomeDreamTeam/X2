using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NUnit.Framework;

namespace X2.NHibernate.Test.Mapping
{
    public class NHibernateTestBase
    {
        private INHibernateService nHibernateService = new NHibernateService(new List<string>(){"X2.Nhibernate"});
        protected ISession session;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            session = nHibernateService.GetCurrentSession();
            nHibernateService.BeginTransaction();
        }


        [TearDown]
        public void TearDown()
        {
            nHibernateService.RollBack();
        }
    }
}
