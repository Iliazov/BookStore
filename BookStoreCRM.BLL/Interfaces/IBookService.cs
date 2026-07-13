using BookStoreCRM.BLL.DTOs.Book;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync();
        Task CreateBookAsync(CreateBookDTO bookDTO);
        Task UpdateBookAsync(UpdateBookDTO bookDTO);
        Task<BookDTO?> GetBookByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
