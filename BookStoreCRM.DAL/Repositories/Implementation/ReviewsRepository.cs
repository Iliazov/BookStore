using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class ReviewsRepository : GenericRepository<Reviews>, IReviewsRepository
    {
        public ReviewsRepository(AppDbContext context) : base(context) { }

        public async Task<Reviews?> GetReviewDetailsAsync(Guid id)
        {
            return await _dbSet
                .Include(r => r.User)
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Reviews>> GetReviewsWithBookAndUser()
        {
            return await _dbSet
                .Include(r => r.User)
                .Include(r => r.Book)
                .ToListAsync();
        }
    }
}
