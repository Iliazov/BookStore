using BookStoreCRM.BLL.DTOs.SubCategory;

namespace BookStoreCRM.BLL.DTOs.Category
{
    public class CategoryWithSubCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<SubCategoryDTO> SubCategories { get; set; } = [];
    }
}
