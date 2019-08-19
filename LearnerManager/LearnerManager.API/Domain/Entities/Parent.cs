using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    public class Parent: EntityBase
    {
        public Guid ParentId { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        [Required(ErrorMessage = "ID number is required")]
        [StringLength(15, ErrorMessage = "ID number cannot be longer then 15 characters")]
        public string IDNumber { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Cellphone body is required")]
        [StringLength(15, ErrorMessage = "SMS body cannot be longer then 100 characters")]
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
 
    }
}
