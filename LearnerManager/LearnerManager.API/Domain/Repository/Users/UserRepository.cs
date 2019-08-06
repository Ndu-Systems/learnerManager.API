using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.Users
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        } 
    }
}
