using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Parent;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.Parent
{
    public class ParentRepository: RepositoryBase<Entities.Parent>, IParentRepository
    {
        public ParentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
