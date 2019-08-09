using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Contracts.SMS;
using LearnerManager.API.Helpers;
using LearnerManager.API.Helpers.Enums;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IRepositoryWrapper _repo;
        public SmsService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public string SaveSms(SmsModel model)
        {
            try
            {
                _repo.Sms.Create(model.ToEntity());
                return SmsEnum.SuccessMessage.GetDescription();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
             
        }
    }
}
