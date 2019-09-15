using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class TwilioModel : EntityBaseModel
    {
        public string SuccessId { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string StatusCode { get; set; }
        public string Error { get; set; }
    }

}
