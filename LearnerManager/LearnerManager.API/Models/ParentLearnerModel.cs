using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class ParentLearnerModel
    {
        [Required] public Guid LearnerId { get; set; }
        [Required] public Guid ParentId { get; set; }
    }

    public class GetLearnersForParentModel : ParentModel
    {
        public List<LearnerModel> LearnerModels { get; set; }
    }

    public class GetParentsForLearnerModel : LearnerModel
    {
        public List<ParentModel> ParentModels { get; set; }
    }
}
