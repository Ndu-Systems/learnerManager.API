using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    public class Parent
    {
        public Guid ParentId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Cellphone body is required")]
        [StringLength(15, ErrorMessage = "SMS body cannot be longer then 100 characters")]
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public int StatusId  { get; set; }
    }

   
}
