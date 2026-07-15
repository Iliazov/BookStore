using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Interfaces
{
    public interface IOrdersRepository : IGenericRepository<Orders>
    {
        Task<Orders?> GetAllOrdersWithItemsAsync(Guid id);
        Task<List<Orders>> GetAllWithCustomerAsync();
    }
}
