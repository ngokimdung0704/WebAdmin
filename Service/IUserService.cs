using System;
using Domain.Models;
using Persistence.Infrastructure;

namespace Service
{
    public interface IUserService : IRepository<User>
    {
    }
}