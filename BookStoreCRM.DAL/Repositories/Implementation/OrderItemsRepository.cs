using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class OrderItemsRepository : GenericRepository<OrderItem>, IOrderItemsRepository
    {
        public OrderItemsRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
