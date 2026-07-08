using BookStoreCRM.DAL.Repositories.Interfaces;

namespace BookStoreCRM.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUserRepository { get; }
        IBooksRepository BooksRepository { get; }
        ICategoriesRepository CategoryRepository { get; }
        IFriendRequestRepository FriendRequestRepository { get; }
        IOrderItemsRepository OrderItemsRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IReviewsRepository ReviewsRepository { get; }
        IWishlistsRepository WishlistsRepository { get; }
        Task Save();
    }
}
