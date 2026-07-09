using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Implementation;
using BookStoreCRM.DAL.Repositories.Interfaces;

namespace BookStoreCRM.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IBooksRepository? _booksRepository;
        private ICategoriesRepository? _categoriesRepository;
        private IOrdersRepository? _ordersRepository;
        private IOrderItemsRepository? _orderItemsRepository;
        private IReviewsRepository? _reviewsRepository;
        private IApplicationUserRepository? _usersRepository;
        private IFriendRequestRepository? _friendRequestsRepository;
        private IWishlistsRepository? _wishlistsRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBooksRepository BooksRepository =>
            _booksRepository ??= new BooksRepository(_context);

        public ICategoriesRepository CategoryRepository =>
            _categoriesRepository ??= new CategoriesRepository(_context);

        public IOrdersRepository OrdersRepository =>
            _ordersRepository ??= new OrdersRepository(_context);

        public IOrderItemsRepository OrderItemsRepository =>
        _orderItemsRepository ??= new OrderItemsRepository(_context);

        public IReviewsRepository ReviewsRepository =>
            _reviewsRepository ??= new ReviewsRepository(_context);

        public IApplicationUserRepository ApplicationUserRepository =>
            _usersRepository ??= new ApplicationUserRepository(_context);

        public IFriendRequestRepository FriendRequestRepository =>
            _friendRequestsRepository ??= new FriendRequestRepository(_context);

        public IWishlistsRepository WishlistsRepository =>
            _wishlistsRepository ??= new WishlistsRepository(_context);


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
