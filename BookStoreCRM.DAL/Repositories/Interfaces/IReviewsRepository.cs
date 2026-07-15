using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Interfaces
{
    public interface IReviewsRepository : IGenericRepository<Reviews>
    {
        Task<Reviews?> GetReviewDetailsAsync(Guid id);
        Task<List<Reviews>> GetReviewsWithBookAndUser();
    }
}
