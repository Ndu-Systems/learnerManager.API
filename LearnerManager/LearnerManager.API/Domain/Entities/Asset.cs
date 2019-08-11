using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    public class Asset
    {
        [Key]
        public Guid AssetId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, ErrorMessage = "SMS body cannot be longer then 50 characters, contact system administrator")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category is required, contact system administrator")]
        public string CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
