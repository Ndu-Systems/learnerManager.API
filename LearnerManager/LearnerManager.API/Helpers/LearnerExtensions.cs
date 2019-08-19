using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class LearnerExtensions
    {
        public static Learner ToEntity(this LearnerModel model)
        {
            return new Learner
            {
                LearnerId = model.LearnerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                IDNumber = model.IDNumber,
                Grade = model.Grade,
                Race = model.Race,
                SchoolName = model.SchoolName,
                Section = model.Section,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
        public static LearnerModel ToModel(this Learner model)
        {
            return new LearnerModel
            {
                LearnerId = model.LearnerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                IDNumber = model.IDNumber,
                Grade = model.Grade,
                Race = model.Race,
                SchoolName = model.SchoolName,
                Section = model.Section,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
    }
}
