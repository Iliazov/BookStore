namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Book
{
    public class BookIndexViewModel
    {
        public List<BookItemViewModel> Books { get; set; } = [];
        public string? Search {  get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
