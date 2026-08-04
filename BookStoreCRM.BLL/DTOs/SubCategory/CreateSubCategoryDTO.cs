namespace BookStoreCRM.BLL.DTOs.SubCategory
{
    public class CreateSubCategoryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
