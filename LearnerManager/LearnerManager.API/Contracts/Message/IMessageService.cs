using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Message
{
    public interface IMessageService
    {
        string SaveMessage(MessageModel model);
    }
}
