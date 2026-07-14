using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(AppDbContext context) : base(context) { }

        public async Task<List<Orders>> GetAllWithCustomerAsync()
        {
            return await _dbSet.Include(o => o.Customer).ToListAsync();
        }
    }
}
