using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Asset
{
    public interface IAssetService
    {
        string CreateAsset(AssetModel model);
        List<AssetModel> GetAll();
        AssetModel GetById(Guid id);
        string UpdateAsset(Guid id,AssetModel model);
    }
}
