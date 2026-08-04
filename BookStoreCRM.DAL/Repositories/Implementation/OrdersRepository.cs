using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(AppDbContext context) : base(context) { }
    }
}
