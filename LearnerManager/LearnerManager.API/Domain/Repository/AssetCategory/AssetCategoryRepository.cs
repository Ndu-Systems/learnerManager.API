using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.AssetCategory;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.AssetCategory
{
    public class AssetCategoryRepository: RepositoryBase<Entities.AssetCategory>, IAssetCategoryRepository
    {
        public AssetCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
