using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Asset;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.Asset
{
    public class AssetRepository: RepositoryBase<Entities.Asset>, IAssetRepository
    {
        public AssetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
