using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Learner;
using LearnerManager.API.Contracts.Message;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Contracts.SMS;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Domain.Repository.Learner;
using LearnerManager.API.Domain.Repository.Message;
using LearnerManager.API.Domain.Repository.SMS;
using LearnerManager.API.Domain.Repository.Users;

namespace LearnerManager.API.Domain.Repository.RepositoryWrapper
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ILearnerRepository _learnerRepository;
        private IMessageRepository _messageRepository;
        private ISMSRepository _smsRepository;
        private IUserRepository _userRepository;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ILearnerRepository Learner
        {
            get
            {
                if (_learnerRepository == null)
                {
                    _learnerRepository = new LearnerRepository(_repositoryContext);
                }

                return _learnerRepository;
            }
        }
        public IMessageRepository Message
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(_repositoryContext);
                }

                return _messageRepository;
            }
        }
        public ISMSRepository Sms
        {
            get
            {
                if (_smsRepository == null)
                {
                    _smsRepository = new SMSRepository(_repositoryContext);
                }

                return _smsRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_repositoryContext);
                }

                return _userRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
