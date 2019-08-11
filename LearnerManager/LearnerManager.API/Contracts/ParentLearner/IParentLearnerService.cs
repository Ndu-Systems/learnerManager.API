﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.ParentLearner
{
    public interface IParentLearnerService
    {
        ParentLearnerModel AddRelationShip(Guid parentId, Guid learnerId);
        List<ParentLearnerModel> GetParentsForLearner(Guid learnerId);
        List<ParentLearnerModel> GetLearnersForParent(Guid parentId);
    }
}
