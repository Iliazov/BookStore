using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class FriendRequestRepository : GenericRepository<FriendRequests>, IFriendRequestRepository
    {
        public FriendRequestRepository(AppDbContext context) : base(context) { }
    }
}
