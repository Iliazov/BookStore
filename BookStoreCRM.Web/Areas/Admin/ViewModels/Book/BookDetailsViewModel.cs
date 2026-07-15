namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Book
{
    public class BookDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
