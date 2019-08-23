using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class ParentLearnerExtensions
    {
        public static ParentLearner ToEntity(this ParentLearnerModel model)
        {
            return new ParentLearner
            {
                Id = model.Id,
                LearnerId = model.LearnerId,
                ParentId = model.ParentId,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
        public static ParentLearnerModel ToModel(this ParentLearner model)
        {
            return new ParentLearnerModel
            {
                Id = model.Id,
                LearnerId = model.LearnerId,
                ParentId = model.ParentId,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
    }
}
