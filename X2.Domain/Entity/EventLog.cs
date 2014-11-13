using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2.Domain.Entity
{
    public class EventLog : IEntity
    {
        public virtual Guid ID { get; set; }

        public virtual Guid UserInforID { get; set; }

        public virtual Guid? LogID { get; set; }

        public virtual string Description { get; set; }

    }
}
