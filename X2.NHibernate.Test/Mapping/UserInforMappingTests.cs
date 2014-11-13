using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using X2.Domain.Entity;

namespace X2.NHibernate.Test.Mapping
{
    [TestFixture]
    public class UserInforMappingTests : NHibernateTestBase
    {
        [SetUp]
        public void SetUp()
        {
            base.SetUp();
        }

        [TearDown]
        public void TearDown()
        {
            base.TearDown();
        }

        [Test]
        public void InsertTest()
        {
            var userInfor = new UserInfor() { Pin = "5678", UserID = "UserID" };
            session.Save(userInfor);
            
        }

        [Test]
        public void DeleteTest()
        {
            var userInfor = new UserInfor() { Pin = "5678", UserID = "UserID" };
            var id = session.Save(userInfor);
            userInfor = session.Get<UserInfor>(id);
            session.Delete(userInfor);
        }

    }
}
