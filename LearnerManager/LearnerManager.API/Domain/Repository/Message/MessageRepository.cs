using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Message;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.Message
{
    public class MessageRepository: RepositoryBase<Entities.Message>, IMessageRepository
    {
        public MessageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
