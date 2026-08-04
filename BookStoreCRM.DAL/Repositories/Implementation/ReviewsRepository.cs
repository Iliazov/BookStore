using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class ReviewsRepository : GenericRepository<Review>, IReviewsRepository
    {
        public ReviewsRepository(AppDbContext context) : base(context) { }

    }
}
