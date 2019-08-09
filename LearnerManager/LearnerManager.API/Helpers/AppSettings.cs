using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Helpers
{
    public class AppSettings
    {
        public string connectionString { get; set; }
        public string Secret { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }


    }
}
