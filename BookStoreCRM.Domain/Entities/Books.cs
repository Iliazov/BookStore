namespace BookStoreCRM.Domain.Entities
{
    public class Books: BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public Categories Category { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
        public ICollection<Wishlists> Wishlists { get; set; } = new List<Wishlists>();

    }
}
