using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2.Domain.Entity
{
    public interface IEntity
    {
        Guid ID { get; set; }
    }
}
