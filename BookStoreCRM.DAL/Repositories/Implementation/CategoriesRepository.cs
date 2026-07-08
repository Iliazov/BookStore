using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class CategoriesRepository :GenericRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
