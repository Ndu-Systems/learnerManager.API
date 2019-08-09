using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class ParentExtensions
    {
        public static Parent ToEntity(this ParentModel model)
        {
            return new Parent
            {
                ParentId = model.ParentId,
                FullName = model.FullName,
                Cellphone = model.Cellphone,
                Email = model.Email,
                Address = model.Address,
                Gender = model.Gender,
                StatusId = model.StatusId
            };
        }
        public static ParentModel ToModel(this Parent model)
        {
            return new ParentModel
            {
                ParentId = model.ParentId,
                FullName = model.FullName,
                Cellphone = model.Cellphone,
                Email = model.Email,
                Address = model.Address,
                Gender = model.Gender,
                StatusId = model.StatusId
            };
        }
    }
}
