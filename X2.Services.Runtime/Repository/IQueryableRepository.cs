using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2.Services.Runtime.Repository
{
    public interface IQueryableRepository<T> : IQueryable<T>
    {
        void SaveOrUpdate(T entity);
        T Get(Guid id);
        void Delete(T entity);
        void Flush();
    }
}
