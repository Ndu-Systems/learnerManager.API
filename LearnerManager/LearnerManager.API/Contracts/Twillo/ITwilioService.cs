using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Models;

namespace LearnerManager.API.Contracts.Twillo
{
    public interface ITwilioService
    {
        TwilioModel SendSms(SmsModel sms);
    }
}
