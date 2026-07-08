using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;

namespace BookStoreCRM.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IApplicationUserRepository ApplicationUserRepository {  get;}

        public IBooksRepository BooksRepository { get; }

        public ICategoriesRepository CategoryRepository { get; }

        public IFriendRequestRepository FriendRequestRepository { get; }

        public IOrderItemsRepository OrderItemsRepository { get; }

        public IOrdersRepository OrdersRepository { get; }

        public IReviewsRepository ReviewsRepository { get; }

        public IWishlistsRepository WishlistsRepository { get; }

        public UnitOfWork(
            AppDbContext context,
            IApplicationUserRepository applicationUserRepository, 
            IBooksRepository booksRepository, 
            ICategoriesRepository categoryRepository,
            IFriendRequestRepository friendRequestRepository, 
            IOrderItemsRepository orderItemsRepository, 
            IOrdersRepository ordersRepository, 
            IReviewsRepository reviewsRepository, 
            IWishlistsRepository wishlistsRepository)
        {
            _context = context;
            ApplicationUserRepository = applicationUserRepository;
            BooksRepository = booksRepository;
            CategoryRepository = categoryRepository;
            FriendRequestRepository = friendRequestRepository;
            OrderItemsRepository = orderItemsRepository;
            OrdersRepository = ordersRepository;
            ReviewsRepository = reviewsRepository;
            WishlistsRepository = wishlistsRepository;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
