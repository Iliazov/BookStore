using System.ComponentModel.DataAnnotations;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.SubCategory
{
    public class SubCategoryFormViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
