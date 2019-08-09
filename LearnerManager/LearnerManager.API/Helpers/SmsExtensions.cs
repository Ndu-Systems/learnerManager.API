using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class SmsExtensions
    {
        public static SMS ToEntity(this SmsModel model)
        {
            return  new SMS
            {
                SMSId = model.SMSId,
                Subject = model.Subject,
                SentTo = model.SendTo,
                Body = model.Body,
                StatusId = model.StatusId
            };
        }
        public static SmsModel ToModel(this SMS model)
        {
            return new SmsModel
            {
                SMSId = model.SMSId,
                Subject = model.Subject,
                SendTo = model.SentTo,
                Body = model.Body,
                StatusId = model.StatusId
            };
        }
    }
}
