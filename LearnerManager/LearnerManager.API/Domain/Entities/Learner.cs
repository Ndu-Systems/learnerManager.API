using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    [Table("learner")]
    public class Learner : EntityBase
    {
        [Key]
        public Guid LearnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "ID number is required")]
        [StringLength(15, ErrorMessage = "ID number cannot be longer then 15 characters")]
        public string IDNumber { get; set; }
        public string SchoolName { get; set; }
        public  string Grade { get; set; }
        public  string Section { get; set; }
    }
}
