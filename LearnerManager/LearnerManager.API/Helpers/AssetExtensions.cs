using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class AssetExtensions
    {
        public static Asset ToEntity(this AssetModel model)
        {
            return new Asset
            {
                AssetId = model.AssetId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
        public static AssetModel ToModel(this Asset model)
        {
            return new AssetModel
            {
                AssetId = model.AssetId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
    }
}
