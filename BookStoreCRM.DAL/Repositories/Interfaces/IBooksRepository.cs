using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Interfaces
{
    public interface IBooksRepository : IGenericRepository<Books>
    {
        Task<Books?> GetBookWithCategoryAsync(Guid id);
    }
}
