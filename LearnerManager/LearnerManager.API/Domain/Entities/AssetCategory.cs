using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Domain.Entities
{
    public class AssetCategory : EntityBase
    {
        [Key] public Guid Id { get; set; }
        [Required] public Guid AssetId { get; set; }
        [Required] public Guid CategoryId { get; set; }
    }
}
