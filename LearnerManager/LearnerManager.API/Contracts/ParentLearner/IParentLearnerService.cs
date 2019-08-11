using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.ParentLearner
{
    public interface IParentLearnerService
    {
        ParentLearnerModel AddRelationShip(Guid parentId, Guid learnerId);
        GetParentsForLearnerModel GetParentsForLearner(Guid learnerId);
        GetParentsForLearnerModel AddParentsForLearner(List<ParentLearnerModel> models, Guid id);
        GetLearnersForParentModel GetLearnersForParent(Guid parentId);
        GetLearnersForParentModel AddLearnersForParent(List<ParentLearnerModel> models, Guid id);
    }
}
