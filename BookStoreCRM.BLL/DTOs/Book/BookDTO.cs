namespace BookStoreCRM.BLL.DTOs.Book
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
    }
}
