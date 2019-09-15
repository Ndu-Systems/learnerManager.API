using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Helpers
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string Secret { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string BulkSms { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
