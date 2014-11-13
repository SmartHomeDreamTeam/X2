using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace X2.NHibernate
{
    public class NHibernateService : INHibernateService
    {
        private readonly ISessionFactory sessionFactory;

        public NHibernateService(IEnumerable<string> assemblynames)
        {
            var configuration = new Configuration().Configure();
            foreach (var assemblyName in assemblynames)
            {
                configuration.AddAssembly(assemblyName);
            }
            sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                session.FlushMode = FlushMode.Commit;
                CurrentSessionContext.Bind(session);
            }

            return sessionFactory.GetCurrentSession();
        }

        public void CloseSession()
        {
            var session = CurrentSessionContext.Unbind(sessionFactory);
            if (session != null && session.Transaction.IsActive)
            {
                session.Close();
            }
        }

        public void BeginTransaction()
        {
            var session = GetCurrentSession();
            session.BeginTransaction();
        }

        public void Flush()
        {
            var session = GetCurrentSession();
            session.Flush();
        }

        public void Commit()
        {
            var session = CurrentSessionContext.Unbind(sessionFactory);
            if (session != null && session.Transaction.IsActive)
            {
                session.Transaction.Commit();
            }
        }

        public void RollBack()
        {
            var session = CurrentSessionContext.Unbind(sessionFactory);
            if (session != null && session.Transaction.IsActive)
            {
                session.Transaction.Rollback();
            }
        }

        public void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}
