using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Interfaces
{
    public interface IOrdersRepository : IGenericRepository<Orders>
    {
        Task<List<Orders>> GetAllWithCustomerAsync();
    }
}
