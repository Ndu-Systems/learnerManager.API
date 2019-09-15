using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Contracts.SMS;
using LearnerManager.API.Helpers;
using LearnerManager.API.Helpers.Enums;
using LearnerManager.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LearnerManager.API.Services.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IConfiguration _config;
        public SmsService(IRepositoryWrapper repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public string SendSms(SmsModel model)
        {
           var bulkSmsModel =  GetSmsConfig();
           var request = SetUpWebRequest(bulkSmsModel);
           RemoveLeadingZero(model);

           var myData  = JsonConvert.SerializeObject(new
           {
               to = model.SentTo,
               body = model.Body
           });
    
            var encoding = new ASCIIEncoding();
            var encodedData = encoding.GetBytes(myData);

            var stream = request.GetRequestStream();
            stream.Write(encodedData, 0 , encodedData.Length);
            stream.Close();
            try
            {
                request.GetResponse();
                return "sms sent successfully";
            }
            catch (WebException e)
            {
                Console.WriteLine("An error was found: "+e.Message);
                throw;
            }
        }

        private static void RemoveLeadingZero(SmsModel model)
        {
// check if 0 in number
            if (model.SentTo.Substring(0, 1) == "0")
            {
                var tempNumber = model.SentTo.Remove(0, 1);
                model.SentTo = "+27" + tempNumber;
            }
        }


        public string SaveSms(SmsModel model)
        {
            try
            {
                _repo.Sms.Create(model.ToEntity());
                _repo.Save();
                return SmsEnum.SuccessMessage.GetDescription();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
             
        }


        #region Helper methods here

        private BulkSMSModel GetSmsConfig()
        {
            var section = _config.GetSection(AppSettingsEnum.BulkSms.GetDescription());

            var smsConfigModel = new BulkSMSModel();

            foreach (var child in section.GetChildren())
            {
                if (child.Key.Equals("Username"))
                    smsConfigModel.Username = child.Value;
                if (child.Key.Equals("Password"))
                    smsConfigModel.Password = child.Value;
                if (child.Key.Equals("URI"))
                    smsConfigModel.Url = child.Value;
            }

            return smsConfigModel;
        }
        private static WebRequest SetUpWebRequest(BulkSMSModel bulkSmsModel)
        {
            var request = WebRequest.Create(bulkSmsModel.Url);
            request.Credentials =
                new NetworkCredential(bulkSmsModel.Username, bulkSmsModel.Password);
            request.PreAuthenticate = true;
            request.Method = "POST";
            request.ContentType = "application/json";
            return request;
        }

        #endregion
    }
}
