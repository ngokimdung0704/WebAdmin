using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext dataContext = null;
        public readonly DbSet<T> table = null;

        public Repository(DataContext datacontext)
        {
            this.dataContext = datacontext;
            table = dataContext.Set<T>();
        }
        public virtual void Add(T entity)
        {
            table.Add(entity);
        }

        public virtual void Detele(T entity)
        {
            table.Remove(entity);
        }

        public virtual void Update(T updatedEntity)
        {
            table.Attach(updatedEntity);
            dataContext.Entry(updatedEntity).State = EntityState.Modified;
        }

        public T Find(int id)
        {
            return table.Find(id);
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filer = null)
        {
            IQueryable<T> query = this.table;

            if(filer != null) query = query.Where(filer);
            return query;
        }
    }
}