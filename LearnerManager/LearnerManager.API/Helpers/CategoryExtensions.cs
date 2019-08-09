using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class CategoryExtensions
    {
        public static Category ToEntity(this CategoryModel model)
        {
            return new Category
            {
                CategoryId = model.CategoryId,
                Description = model.Description,
                StatusId = model.StatusId
            };
        }
        public static CategoryModel ToModel(this Category model)
        {
            return new CategoryModel
            {
                CategoryId = model.CategoryId,
                Description = model.Description,
                StatusId = model.StatusId
            };
        }
    }
}
