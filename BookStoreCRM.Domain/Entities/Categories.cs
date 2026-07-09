namespace BookStoreCRM.Domain.Entities
{
    public class Categories: BaseEntity
    {
        public string Name {  get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Books> Books { get; set; } = new List<Books>();
    }
}
