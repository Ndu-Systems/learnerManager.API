using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class AssetCategoryExtensions
    {
        public static AssetCategory ToEntity(this AssetCategoryModel model)
        {
            return new AssetCategory
            {
                Id = model.Id,
                AssetId = model.AssetId,
                CategoryId = model.CategoryId,
                CreateUserId =  model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }

        public static AssetCategoryModel ToModel(this AssetCategory model)
        {
            return new AssetCategoryModel
            {
                Id = model.Id,
                AssetId = model.AssetId,
                CategoryId = model.CategoryId,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }

    }
}
