using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Learner
{
    public interface ILearnerService
    {
        List<LearnerModel> GetAllLearners();
        LearnerModel GetById(Guid id);
        LearnerModel CreateLearner(LearnerModel model);
        LearnerModel UpdateLearner(Guid id,LearnerModel model);

    }
}
