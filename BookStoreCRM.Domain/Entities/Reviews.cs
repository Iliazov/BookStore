namespace BookStoreCRM.Domain.Entities
{
    public class Reviews : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUsers User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Books Book { get; set; } = null!;
        public int Grade { get; set; }
        public string? Comment { get; set; }
    }
}
