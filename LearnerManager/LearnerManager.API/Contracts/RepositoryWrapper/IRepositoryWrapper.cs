using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Learner;
using LearnerManager.API.Contracts.Message;
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
        void Save();
    }
}
