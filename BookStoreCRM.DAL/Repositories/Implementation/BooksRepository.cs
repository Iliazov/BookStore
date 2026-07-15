using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class BooksRepository : GenericRepository<Books>, IBooksRepository
    {
        public BooksRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Books?> GetBookWithCategoryAsync(Guid id)
        {
            return await _dbSet.Include(b => b.Category).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
