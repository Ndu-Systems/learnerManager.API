﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Asset;
using LearnerManager.API.Contracts.AssetCategory;
using LearnerManager.API.Contracts.Category;
using LearnerManager.API.Contracts.Learner;
using LearnerManager.API.Contracts.Message;
using LearnerManager.API.Contracts.Parent;
using LearnerManager.API.Contracts.ParentLearner;
using LearnerManager.API.Contracts.SMS;
using LearnerManager.API.Contracts.Users;

namespace LearnerManager.API.Contracts.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        ILearnerRepository Learner { get; }
        IMessageRepository Message { get; }
        ISMSRepository Sms { get; }
        IUserRepository User { get; }
        IAssetRepository Asset { get; }
        ICategoryRepository Category { get; }
        IParentRepository Parent { get; }
        IParentLearnerRepository ParentLearner { get; }
        IAssetCategoryRepository AssetCategory { get; }
        void Save();
    }
}
