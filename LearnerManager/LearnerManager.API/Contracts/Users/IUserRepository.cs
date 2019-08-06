using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryBase;
using LearnerManager.API.Domain.Entities;

namespace LearnerManager.API.Contracts.Users
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
