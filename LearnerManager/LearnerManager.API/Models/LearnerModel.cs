using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class LearnerModel : EntityBaseModel
    {
 
        public Guid LearnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string DateOfBirth { get; set; }
        public string IDNumber { get; set; }
        public string SchoolName { get; set; }
        public string Grade { get; set; }
        public string Section { get; set; }
        public int StatusId { get; set; }
    }
   
}
