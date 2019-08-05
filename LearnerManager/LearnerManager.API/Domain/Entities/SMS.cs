using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    [Table("sms")]
    public class SMS
    {
        public Guid SMSId { get; set; }
        public string Subject { get; set; }
        public string SentTo { get; set; }
        public string Body { get; set; }
        public int StatusId { get; set; }
    }
}
