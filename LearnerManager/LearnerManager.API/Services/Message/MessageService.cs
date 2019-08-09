using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Message;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Helpers.Enums;
using LearnerManager.API.Models;

namespace LearnerManager.API.Services.Message
{
    public class MessageService : IMessageService
    {
        private readonly IRepositoryWrapper _repo;
        public MessageService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public string SaveMessage(MessageModel model)
        {
            try
            {
                _repo.Message.Create(model.ToEntity());
                return SmsEnum.SuccessMessage.GetDescription();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
