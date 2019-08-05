using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Learner;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.Learner
{
    public class LearnerRepository: RepositoryBase<Entities.Learner>, ILearnerRepository
    {
        public LearnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
