using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class CategoryModel : EntityBaseModel
    {
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
