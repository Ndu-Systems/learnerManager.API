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
                SentTo = model.SentTo,
                Body = model.Body,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
        public static SmsModel ToModel(this SMS model)
        {
            return new SmsModel
            {
                SMSId = model.SMSId,
                Subject = model.Subject,
                SentTo = model.SentTo,
                Body = model.Body,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
    }
}
