using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    [Table("message")]
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; }
        public string MessageType { get; set; }
        public string MessageBody { get; set; }
    }
}
