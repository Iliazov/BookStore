namespace BookStoreCRM.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name {  get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPopular { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; } = [];
        public ICollection<Book> Books { get; set; } = [];
    }
}
