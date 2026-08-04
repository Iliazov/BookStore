using BookStoreCRM.Web.Models.Book;
using BookStoreCRM.Web.Models.Category;

namespace BookStoreCRM.Web.Models.Home
{
    public class HomeViewModel
    {
        public List<BookViewModel> Books { get; set; } = [];
        public List<CategoryViewModel> Categories { get; set; } = [];
    }
}
