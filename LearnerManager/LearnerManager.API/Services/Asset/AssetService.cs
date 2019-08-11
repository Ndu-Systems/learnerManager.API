using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Asset;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Helpers.Enums;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.Asset
{
    public class AssetService: IAssetService
    {
        private readonly IRepositoryWrapper _repo;
        public AssetService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public AssetModel CreateAsset(AssetModel model)
        {
            try
            {
                model.AssetId = Guid.NewGuid();
                model.StatusId = 1;
                _repo.Asset.Create(model.ToEntity());
                _repo.Save();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public List<AssetModel> GetAll()
        {
            try
            {
               return _repo.Asset.FindAll().Select(x => x.ToModel()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public AssetModel GetById(Guid id)
        {
            return _repo.Asset.FindAll().FirstOrDefault(x => x.AssetId == id).ToModel();
        }

        public AssetModel UpdateAsset(Guid id,AssetModel model)
        {
            try
            {
                var assetModel = GetById(id);
                if (assetModel != null)
                {
                    assetModel.AssetId = model.AssetId;
                    assetModel.Description = model.Description;
                    assetModel.CategoryId = model.CategoryId;
                    assetModel.CategoryId = model.CategoryId;
                    assetModel.StatusId = model.StatusId;
                    _repo.Asset.Update(assetModel.ToEntity());
                    _repo.Save();
                    return assetModel;
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public AssetWithCategoryModel GetAssetWithCategoryModel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
