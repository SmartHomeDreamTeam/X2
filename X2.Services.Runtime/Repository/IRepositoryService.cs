using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;

namespace X2.Services.Runtime.Repository
{
    public interface IRepositoryService
    {
        IQueryableRepository<T> Queryover<T>();
    }
}
