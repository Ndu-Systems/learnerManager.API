﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Twilio.Clients;
using Twilio.Http;


namespace LearnerManager.API.Services.Communications
{
    public class CustomTwilioClient : ITwilioRestClient
    {
        private readonly ITwilioRestClient _innerClient;

        public CustomTwilioClient(IConfiguration config, System.Net.Http.HttpClient httpClient)
        {

             _innerClient = new TwilioRestClient(
                config["Twilio:AccountSid"],
                config["Twilio:AuthToken"],
                httpClient: new SystemNetHttpClient(httpClient));
        }

        public Response Request(Request request) => _innerClient.Request(request);
        public Task<Response> RequestAsync(Request request) => _innerClient.RequestAsync(request);
        public string AccountSid => _innerClient.AccountSid;
        public string Region => _innerClient.Region;
        public Twilio.Http.HttpClient HttpClient => _innerClient.HttpClient;
    }
}