using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleInjector;
using X2.Bootstrapper;
using X2.NHibernate;
using X2.Services.Runtime.FirstService;

namespace X2.Test.BootStrapper
{
    [TestFixture]
    public class BootStrapperbaseTest
    {
        [Test]
        public void InitialTest()
        {
            var result = new FakeBootStrapper().Boot();
            Assert.That(result.GetInstance<IHelloWorldService>(), Is.Not.Null);
        }

        [Test]
        public void InitialService_RepositoryServiceIsNotRuningTest()
        {
            var result = new FakeBootStrapper().Boot();
            Assert.Throws<SimpleInjector.ActivationException>(() => result.GetInstance<INHibernateService>());
        }
    }

    internal class FakeBootStrapper : BootStrapperbase
    {
        public override Container Boot()
        {
            return base.Initial();
        }
    }
}
