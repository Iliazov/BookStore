namespace BookStoreCRM.Domain.Entities
{
    public class Wishlists : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUsers User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Books Book { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
