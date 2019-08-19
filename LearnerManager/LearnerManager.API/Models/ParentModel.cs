using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
 
    public class ParentModel : EntityBaseModel
    {
        public Guid ParentId { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public string IDNumber { get; set; }
        public string Gender { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
    }
}
