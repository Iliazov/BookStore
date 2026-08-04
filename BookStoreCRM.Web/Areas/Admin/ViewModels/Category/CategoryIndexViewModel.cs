namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Category
{
    public class CategoryIndexViewModel
    {
        public List<CategoryViewModel> Categories { get; set; } = [];
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
