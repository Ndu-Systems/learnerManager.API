using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.SMS
{
    public interface ISmsService
    {
        string SendSms(SmsModel model);
        string SaveSms(SmsModel model);
    }
}
