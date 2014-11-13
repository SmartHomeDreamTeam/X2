using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2.Services.Runtime.FirstService;

namespace X2.Services.Runtime.Implementation.HelloWorld
{
    public class HelloWorldService : IHelloWorldService
    {
        private int randamNumber ;

        public void SetRandamNumber()
        {
            var random = new Random();
            randamNumber = random.Next(1, 10000);
        }

        public int GetRandam {
            get
            {
                return randamNumber;
            }
            private set { }
        }

        public int Add(int i, int j)
        {
            return i + j;
        }
    }
}
