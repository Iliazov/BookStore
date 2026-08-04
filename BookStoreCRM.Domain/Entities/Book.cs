namespace BookStoreCRM.Domain.Entities
{
    public class Book: BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public SubCategory? SubCategory { get; set; } = null!;
        public Guid? SubCategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();

    }
}
