using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using X2.Services.Runtime.Implementation.HelloWorld;


namespace X2.Test.Service.Runtime.Implementation.HelloWorld
{
    [TestFixture]
    public class HelloWorldServiceTests
    {
        [Test]
        public void AddTest()
        {
            var helloWorldService = new HelloWorldService();
            var result = helloWorldService.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
