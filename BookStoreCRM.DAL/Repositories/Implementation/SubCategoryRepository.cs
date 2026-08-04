using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
