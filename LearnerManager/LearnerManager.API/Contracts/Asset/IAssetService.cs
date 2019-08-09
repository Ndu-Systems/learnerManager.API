using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Asset
{
    public interface IAssetService
    {
        AssetModel CreateAsset(AssetModel model);
        List<AssetModel> GetAll();
        AssetModel GetById(Guid id);
        AssetModel UpdateAsset(Guid id,AssetModel model);
    }
}
