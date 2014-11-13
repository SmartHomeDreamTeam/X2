using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2.Domain.Entity
{
    public class UserInfor : IEntity
    {
        public virtual Guid ID { get; set; }

        public virtual string UserID { get; set; }

        public virtual string Pin { get; set; }

        public virtual IList<Session> Sessions { get; protected set; }

        public virtual void Add(Session session)
        {
            session.UserInfor = this;
            if (Sessions == null)
            {
                Sessions = new List<Session>();
            }
            this.Sessions.Add(session);
        }

    }
}
