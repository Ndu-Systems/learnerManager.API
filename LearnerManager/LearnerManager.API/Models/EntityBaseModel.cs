using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class EntityBaseModel
    {
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid ModifyUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public int StatusId { get; set; }
    }
}
