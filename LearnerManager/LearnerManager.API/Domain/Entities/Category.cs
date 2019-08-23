using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    public class Category : EntityBase
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
