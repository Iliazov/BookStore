namespace BookStoreCRM.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Book> Books { get; set; } = [];
    }
}
