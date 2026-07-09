using BookStoreCRM.BLL.DTOs.Book;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync();
    }
}
