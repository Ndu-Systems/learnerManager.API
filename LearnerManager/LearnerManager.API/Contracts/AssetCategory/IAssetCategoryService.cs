using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.AssetCategory
{
    public interface IAssetCategoryService
    {
      
        GetCategoriesForAssetModel GetCategoriesForAsset(Guid assetId);
        GetCategoriesForAssetModel AddCategoriesForAsset(List<AssetCategoryModel> models, Guid assetId);
        GetAssetsForCategoryModel GetAssetsForCategory(Guid categoryId);
        GetAssetsForCategoryModel AddAssetsForCategory(List<AssetCategoryModel> models, Guid categoryId);
    }
}
