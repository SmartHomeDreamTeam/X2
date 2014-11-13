using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using X2.NHibernate;
using X2.Services.Runtime.Repository;

namespace X2.Services.Runtime.Implementation.Repository
{
    public class QueryableRepository<T> : IQueryableRepository<T>
    {
        private INHibernateService nHibernateService;

        public QueryableRepository(INHibernateService nHibernateService)
        {
            this.nHibernateService = nHibernateService;
        }

        public Type ElementType
        {
            get { return nHibernateService.GetCurrentSession().Query<T>().ElementType; }
        }

        public Expression Expression
        {
            get { return nHibernateService.GetCurrentSession().Query<T>().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return nHibernateService.GetCurrentSession().Query<T>().Provider; }
        }

        public void SaveOrUpdate(T entity)
        {
            nHibernateService.GetCurrentSession().SaveOrUpdate(entity);
        }

        public T Get(Guid id)
        {
            return nHibernateService.GetCurrentSession().Get<T>(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return nHibernateService.GetCurrentSession().Query<T>().GetEnumerator();
        }

        public void Delete(T entity)
        {
            nHibernateService.GetCurrentSession().Delete(entity);
        }

        public void Flush()
        {
            nHibernateService.Flush();
        }
    }
}
