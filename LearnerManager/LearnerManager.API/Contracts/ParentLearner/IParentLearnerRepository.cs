using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryBase;

namespace LearnerManager.API.Contracts.ParentLearner
{
    public interface IParentLearnerRepository: IRepositoryBase<Domain.Entities.ParentLearner>
    {
    }
}
