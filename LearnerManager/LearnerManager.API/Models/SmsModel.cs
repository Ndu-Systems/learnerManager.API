using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class SmsModel : EntityBaseModel
    {
        [Key]
        public Guid SMSId { get; set; }
        public string Subject { get; set; }
        public string SentTo { get; set; }
        public string FromNumber { get; set; }
        [Required(ErrorMessage = "SMS body is required")]
        [StringLength(100, ErrorMessage = "SMS body cannot be longer then 100 characters")]
        public string Body { get; set; }
     }


    public class BulkSMSModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
    }
}
