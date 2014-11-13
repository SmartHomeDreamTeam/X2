using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace X2.NHibernate
{
    public interface INHibernateService
    {
        ISession GetCurrentSession();
        void CloseSession();
        void BeginTransaction();
        void Flush();
        void Commit();
        void RollBack();
        void CloseSessionFactory();
    }
}
