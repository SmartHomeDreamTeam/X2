using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2.Services.Runtime.FirstService
{
    public interface IHelloWorldService
    {
        int GetRandam { get; }
    
        int Add(int i, int j);

        void SetRandamNumber();
    }
}
