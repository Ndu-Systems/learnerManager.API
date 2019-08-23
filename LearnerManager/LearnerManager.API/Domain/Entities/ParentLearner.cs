using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    public class ParentLearner: EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required] public Guid LearnerId { get; set; }
        [Required] public Guid ParentId { get; set; }
    }
}
