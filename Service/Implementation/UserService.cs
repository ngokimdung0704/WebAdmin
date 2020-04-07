using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Models;
using Persistence;
using Persistence.Infrastructure;

namespace Service.Implementation
{
    public class UserService : Repository<User>, IUserService
    {
        public UserService(DataContext datacontext) : base(datacontext)
        {
        }
    }
}