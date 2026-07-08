using BookStoreCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Context
{
    public class AppDbContext: IdentityDbContext<ApplicationUsers, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        DbSet<Books> Books { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<OrderItems> Items { get; set; }
        DbSet<Categories> Categories { get; set; }
        DbSet<Reviews> Reviews { get; set; }
        DbSet<Wishlists> Wishlists { get; set; }
        DbSet<FriendRequests> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
