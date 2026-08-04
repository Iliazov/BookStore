namespace BookStoreCRM.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public int Grade { get; set; }
        public string? Comment { get; set; }
    }
}
