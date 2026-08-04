namespace BookStoreCRM.Domain.Entities
{
    public class Wishlist : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
