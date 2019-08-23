using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Models
{
    public class AssetCategoryModel : EntityBaseModel
    {
        public Guid Id { get; set; }
        [Required] public Guid AssetId { get; set; }
        [Required] public Guid CategoryId { get; set; }
    }

    public class GetCategoriesForAssetModel : AssetModel
    {
        public List<CategoryModel> Categories { get; set; }
        public List<string> Errors { get; set; }
    }

    public class GetAssetsForCategoryModel : CategoryModel
    {
        public List<AssetModel> Assets { get; set; }
        public List<string> Errors { get; set; }
    }
}
