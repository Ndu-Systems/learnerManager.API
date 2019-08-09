using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
