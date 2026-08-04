using BookStoreCRM.BLL.DTOs.Book;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IBookService
    {
        Task CreateBookAsync(CreateBookDTO bookDTO);
        Task UpdateBookAsync(UpdateBookDTO bookDTO);
        Task<BookDTO?> GetBookByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<BookDetailsDTO> GetBookWithCategoryAsync(Guid id);
        Task<(List<BookDTO> Books, int PageSize)> GetAllBooksAsync(string? search, int page, int pageSize);
        Task<List<BookDTO>> GetAllBooksAsync();
    }
}
