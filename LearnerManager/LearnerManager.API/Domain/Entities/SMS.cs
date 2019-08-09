using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    [Table("sms")]
    public class SMS
    {
        [Key]
        public Guid SMSId { get; set; }
        public string Subject { get; set; }
        public string SendTo { get; set; }
        [Required(ErrorMessage = "SMS body is required")]
        [StringLength(100, ErrorMessage = "SMS body cannot be longer then 100 characters")]
        public string Body { get; set; }
        public int StatusId { get; set; }
    }
}
