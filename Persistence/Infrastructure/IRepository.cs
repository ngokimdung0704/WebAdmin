using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Persistence.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Detele(T entity);
        void Update(T entity);

        T Find(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filer = null);
    }
}