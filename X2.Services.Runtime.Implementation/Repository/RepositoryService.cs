using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using X2.NHibernate;
using X2.Services.Runtime.Repository;
using Expression = NHibernate.Criterion.Expression;

namespace X2.Services.Runtime.Implementation.Repository
{
    public class RepositoryService : IRepositoryService
    {
        private readonly INHibernateService nHibernateService;

        public RepositoryService(INHibernateService  nHibernateService )
        {
            this.nHibernateService = nHibernateService;
        }

        public IQueryableRepository<T> Queryover<T>()
        {
            return new QueryableRepository<T>(nHibernateService);
        }
    }
}
