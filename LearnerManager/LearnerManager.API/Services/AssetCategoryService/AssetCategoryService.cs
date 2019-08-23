using System;
using System.Collections.Generic;
using System.Linq;
using LearnerManager.API.Contracts.Asset;
using LearnerManager.API.Contracts.AssetCategory;
using LearnerManager.API.Contracts.Category;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.AssetCategoryService
{
    public class AssetCategoryService: IAssetCategoryService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly ICategoryService _categoryService;
        private readonly IAssetService _assetService;
        public AssetCategoryService(IRepositoryWrapper repo, ICategoryService categoryService, IAssetService assetService)
        {
            _repo = repo;
            _categoryService = categoryService;
            _assetService = assetService;
        }
        private AssetCategoryModel AddRelationShip(Guid assetId, Guid categoryId)
        {
            try
            {
                var assetCategoryModel = new AssetCategoryModel
                {
                    Id = Guid.NewGuid(),
                    AssetId = assetId,
                    CategoryId = categoryId
                };
                _repo.AssetCategory.Create(assetCategoryModel.ToEntity());
                _repo.Save();
                return assetCategoryModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public GetCategoriesForAssetModel GetCategoriesForAsset(Guid assetId)
        {
            try
            {
                var asset = _assetService.GetById(assetId);
                if (asset != null)
                {
                    var assetModel = new GetCategoriesForAssetModel
                    {
                        AssetId = asset.AssetId,
                        Description = asset.Description,
                        StatusId = asset.StatusId
                    };
                    assetModel.Categories = new List<CategoryModel>();
                    assetModel.Errors = new List<string>();
                    var assetCategories = _repo.AssetCategory.FindAll()
                        .Where(x => x.AssetId == assetModel.AssetId)
                        .Select(x => x.ToModel()).ToList();

                    if (assetCategories.Count > 0)
                    {
                        foreach (var categoryItem in assetCategories)
                        {
                            var categoryModel = _categoryService.GetById(categoryItem.CategoryId);
                            if (categoryModel != null)
                            {
                                var exists =
                                    assetModel.Categories.FirstOrDefault(x => x.CategoryId == categoryModel.CategoryId);
                                if(exists==null) assetModel.Categories.Add(categoryModel);
                            }
                            else
                            {
                                assetModel.Errors.Add("Could not find category entity: Id= "+ categoryItem.CategoryId);
                            }
                        }
                    }
                    else
                    {
                        assetModel.Errors.Add("Could not find categories for asset entity: id= "+assetModel.AssetId);
                    }

                    return assetModel;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public GetCategoriesForAssetModel AddCategoriesForAsset(List<AssetCategoryModel> models, Guid assetId)
        {
            try
            {
                var asset = _assetService.GetById(assetId);
                if (asset != null)
                {
                    var assetModel = GetCategoriesForAsset(asset.AssetId);
                    assetModel.Errors = new List<string>();

                    foreach (var model in models)
                    {
                        var categoryModel = _categoryService.GetById(model.CategoryId);
                        if (categoryModel != null)
                        {
                            var exists =
                                assetModel.Categories.FirstOrDefault(x => x.CategoryId == categoryModel.CategoryId);
                            if (exists == null)
                            {
                                var result = AddRelationShip(assetModel.AssetId, categoryModel.CategoryId);
                                if (result.Id != null)
                                {
                                    assetModel.Categories.Add(categoryModel);
                                }
                            }
                            else
                            {
                                assetModel.Errors
                                    .Add("Category entity: Id= "+ categoryModel.CategoryId+" already exists");
                            }
                        }
                        else
                        {
                            assetModel.Errors
                                .Add("Could not find category with entity: id= "+ model.CategoryId);
                        }
                    }

                    return assetModel;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        public GetAssetsForCategoryModel GetAssetsForCategory(Guid categoryId)
        {
            try
            {
                var category = _categoryService.GetById(categoryId);
                if (category != null)
                {
                    var categoryModel = new GetAssetsForCategoryModel
                    {
                        CategoryId = category.CategoryId,
                        Description = category.Description,
                        StatusId = category.StatusId
                    };
                    categoryModel.Assets = new List<AssetModel>();
                    categoryModel.Errors = new List<string>();

                    var categoryAssets = _repo.AssetCategory.FindAll()
                        .Where(x => x.CategoryId == categoryModel.CategoryId)
                        .Select(x => x.ToModel()).ToList();
                    if (categoryAssets.Count > 0)
                    {
                        foreach (var assetItem in categoryAssets)
                        {
                            var assetModel = _assetService.GetById(assetItem.AssetId);
                            if (assetModel != null)
                            {
                                var exists =
                                    categoryModel.Assets.FirstOrDefault(x => x.AssetId == assetItem.AssetId);
                                if (exists == null)
                                {
                                    categoryModel.Assets.Add(assetModel);
                                }
                            }
                            else
                            {
                                categoryModel.Errors.Add("Could not find asset entity: Id= "+ assetItem.AssetId);
                            }
                        }
                    }
                    else
                    {
                        categoryModel.Errors.Add("Could not find assets for category entity: id= "+categoryModel.CategoryId);
                    }

                    return categoryModel;
                }
                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        public GetAssetsForCategoryModel AddAssetsForCategory(List<AssetCategoryModel> models, Guid categoryId)
        {
            try
            {
                var category = _categoryService.GetById(categoryId);
                if (category != null)
                {
                    var categoryModel = GetAssetsForCategory(category.CategoryId);
                    categoryModel.Errors = new List<string>();
                    foreach (var model in models)
                    {
                        var assetModel = _assetService.GetById(model.AssetId);
                        if (assetModel != null)
                        {
                            var exists = categoryModel.Assets.FirstOrDefault(x => x.AssetId == assetModel.AssetId);
                            if (exists == null)
                            {
                                var result = AddRelationShip(assetModel.AssetId, categoryModel.CategoryId);
                                if (result.Id != null)
                                {
                                    categoryModel.Assets.Add(assetModel);
                                }
                            }
                            else
                            {
                                categoryModel.Errors.Add("Asset entity: Id= "+assetModel.AssetId+" already exists");
                            }
                        }
                        else
                        {
                            categoryModel.Errors.Add("Could not find  asset with entity: Id= "+model.AssetId);
                        }
                    }

                    return categoryModel;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
