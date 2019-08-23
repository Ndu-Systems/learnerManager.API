using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Models;

namespace LearnerManager.API.Helpers
{
    public static class MessageExtensions
    {
        public static Message ToEntity(this MessageModel model)
        {
            return new Message
            {
                MessageId = model.MessageId,
                MessageType = model.MessageType,
                MessageBody = model.MessageBody,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
        public static MessageModel ToModel(this Message model)
        {
            return new MessageModel
            {
                MessageId = model.MessageId,
                MessageType = model.MessageType,
                MessageBody = model.MessageBody,
                CreateUserId = model.CreateUserId,
                CreateDate = model.CreateDate,
                ModifyUserId = model.ModifyUserId,
                ModifyDate = model.ModifyDate,
                StatusId = model.StatusId
            };
        }
    }
}
