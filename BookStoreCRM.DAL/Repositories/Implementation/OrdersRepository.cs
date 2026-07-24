using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(AppDbContext context) : base(context) { }

        public async Task<bool> CheckCustomerOrdersAsync(Guid Id)
        {
            return await _dbSet.AnyAsync(c => c.CustomerId == Id);
        }

        public async Task<Orders?> GetAllOrdersWithItemsAsync(Guid id)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Book)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Orders>> GetAllWithCustomerAsync()
        {
            return await _dbSet.Include(o => o.Customer).ToListAsync();
        }
    }
}
