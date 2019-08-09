using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class SmsModel
    {
        [Key]
        public Guid SMSId { get; set; }
        public string Subject { get; set; }
        public string SendTo { get; set; }
        public string FromNumber { get; set; }
        [Required(ErrorMessage = "SMS body is required")]
        [StringLength(100, ErrorMessage = "SMS body cannot be longer then 100 characters")]
        public string Body { get; set; }
        public int StatusId { get; set; }
    }
}
