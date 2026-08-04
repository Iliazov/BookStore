using BookStoreCRM.Web.Areas.Admin.ViewModels.SubCategory;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Category
{
    public class CategoryWithSubCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<SubCategoryViewModel> SubCategories { get; set; } = [];
    }
}
