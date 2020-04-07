using System;

namespace Persistence.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Commit()
        {
            dataContext.SaveChanges();
        }
    }
}