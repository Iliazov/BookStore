using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class WishlistsRepository : GenericRepository<Wishlists>, IWishlistsRepository
    {
        public WishlistsRepository(AppDbContext context) : base(context) { }
    }
}
