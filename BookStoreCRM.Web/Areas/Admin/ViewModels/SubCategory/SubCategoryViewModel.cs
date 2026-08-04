using System.ComponentModel.DataAnnotations;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.SubCategory
{
    public class SubCategoryViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
