using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    internal class BooksRepository : GenericRepository<Books>, IBooksRepository
    {
        public BooksRepository(AppDbContext context) : base(context)
        {
        }
    }
}
