using System;

namespace Persistence.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}