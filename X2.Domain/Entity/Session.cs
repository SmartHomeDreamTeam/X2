using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2.Domain.Entity
{
    public class Session : IEntity
    {
        public virtual Guid ID { get; set; }

        public virtual UserInfor UserInfor { get; set; }

        public virtual Guid UserInforID { get; set; }

        public virtual string SecretKey { get; set; }

        public virtual DateTime CreatedDateTime { get; set; }

        public virtual string CreatedBy { get; set; }
    }
}
