using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryBase;

namespace LearnerManager.API.Contracts.Asset
{
    public interface IAssetRepository: IRepositoryBase<Domain.Entities.Asset>
    {
    }
}
