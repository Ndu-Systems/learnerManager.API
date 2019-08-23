using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryBase;

namespace LearnerManager.API.Contracts.AssetCategory
{
    public interface IAssetCategoryRepository: IRepositoryBase<Domain.Entities.AssetCategory>
    {
    }
}
