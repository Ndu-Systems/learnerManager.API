using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.SMS;
using LearnerManager.API.Domain.Repository.RepositoryBase;

namespace LearnerManager.API.Domain.Repository.SMS
{
    public class SMSRepository: RepositoryBase<Entities.SMS>, ISMSRepository
    {
        public SMSRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
