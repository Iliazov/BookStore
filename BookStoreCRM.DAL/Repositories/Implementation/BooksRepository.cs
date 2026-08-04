using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        public BooksRepository(AppDbContext context) : base(context)
        {
        }

    }
}
