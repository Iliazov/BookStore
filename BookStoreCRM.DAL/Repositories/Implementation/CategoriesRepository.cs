using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class CategoriesRepository :GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(AppDbContext dbContext) : base(dbContext) { }

    }
}
