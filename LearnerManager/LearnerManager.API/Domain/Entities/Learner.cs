using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    [Table("learner")]
    public class Learner
    {
        [Key]
        public Guid LearnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentName { get; set; }
        public string ParentContactNumber { get; set; }
        public int StatusId { get; set; }
    }
}
