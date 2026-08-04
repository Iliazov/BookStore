namespace BookStoreCRM.BLL.DTOs.SubCategory
{
    public class SubCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid Categoryid { get; set; }
    }
}
