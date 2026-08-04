using BookStoreCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.DAL.Context
{
    public class AppDbContext: IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        DbSet<Book> Books { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> Items { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Wishlist> Wishlists { get; set; }
        DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
