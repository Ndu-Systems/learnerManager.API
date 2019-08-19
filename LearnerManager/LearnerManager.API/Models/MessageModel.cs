using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class MessageModel: EntityBaseModel
    {
        public Guid MessageId { get; set; }
        public string MessageType { get; set; }
        public string MessageBody { get; set; }
    }
}
