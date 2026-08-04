using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.DAL.Repositories.Implementation
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
