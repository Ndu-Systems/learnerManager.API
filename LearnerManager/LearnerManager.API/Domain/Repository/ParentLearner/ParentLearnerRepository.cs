using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.ParentLearner;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.ParentLearner
{
    public class ParentLearnerRepository: RepositoryBase<Domain.Entities.ParentLearner>, IParentLearnerRepository
    {
        public ParentLearnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
