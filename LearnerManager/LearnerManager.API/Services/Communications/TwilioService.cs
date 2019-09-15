using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Message;
using LearnerManager.API.Contracts.SMS;
using LearnerManager.API.Contracts.Twillo;
using LearnerManager.API.Helpers;
using LearnerManager.API.Helpers.Enums;
using LearnerManager.API.Models;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace LearnerManager.API.Services.Communications
{
    public class TwilioService : ITwilioService
    {
        private readonly ITwilioRestClient _client;
        private readonly IMessageService _messageService;
        private readonly ISmsService _smsService;

        public TwilioService(
            ITwilioRestClient client,
            IMessageService messageService,
            ISmsService smsService)
        {
            _client = client;
            _messageService = messageService;
            _smsService = smsService;
        }
        public TwilioModel SendSms(SmsModel sms)
        {
            //#if DEBUG
            //            var message = new
            //            {
            //                Sid = "debugging"
            //            };
            //#else
             
                        var message = MessageResource.Create(
                            to: new PhoneNumber(sms.SentTo),
                            from: new PhoneNumber(sms.FromNumber),
                            body: sms.Subject + "  " + sms.Body + " " + DateTime.Now.ToShortDateString(),
                            client: _client); // pass in the custom client
            //#endif

            if (!string.IsNullOrEmpty(message.Sid))
            {
                var messageModel = new MessageModel
                {
                    MessageId = Guid.NewGuid(),
                    MessageType = sms.Subject,
                    MessageBody = sms.Body + " " + DateTime.Now.ToShortDateString()
                };
                var smsModel = new SmsModel
                {
                    SMSId = Guid.NewGuid(),
                    Subject = sms.Subject + "Id:" + message.Sid + "_" + Guid.NewGuid().ToString().Substring(5, 9),
                    SentTo = sms.SentTo,
                    Body = sms.Body + " " + DateTime.Now.ToShortDateString(),
                    FromNumber = sms.FromNumber,
                    StatusId = 1
                };
                var errors = string.Empty;
                var saveMessage = _messageService.SaveMessage(messageModel);
                var saveSms = _smsService.SaveSms(smsModel);
                if (string.IsNullOrEmpty(saveMessage))
                {
                    errors += "message not saved .";
                }

                if (string.IsNullOrEmpty(saveSms))
                {
                    errors += "sms not saved .";
                }
                return  new TwilioModel
                {
                    StatusCode = SmsEnum.SuccessMessage.ToString(),
                    SuccessId = message.Sid+"_"+Guid.NewGuid().ToString().Substring(5,9),
                    Error = errors
                };
            }

            return new TwilioModel
            {
                StatusCode = SmsEnum.ErrorMessage.ToString(),
                SuccessId = Guid.NewGuid().ToString().Substring(5, 9),
                 Error = SmsEnum.ErrorMessage.GetDescription()
            };
        }
    }
}
