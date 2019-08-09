using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.SMS
{
    public interface ISmsService
    {
        string SaveSms(SmsModel model);
    }
}
