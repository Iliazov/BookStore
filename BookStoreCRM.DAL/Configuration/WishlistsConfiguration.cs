using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class WishlistsConfiguration : IEntityTypeConfiguration<Wishlists>
    {
        public void Configure(EntityTypeBuilder<Wishlists> builder)
        {
            builder.ToTable(nameof(Wishlists));
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.User)
                   .WithMany(u => u.Wishlists)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(w => w.Book)
                   .WithMany(b => b.Wishlists)
                   .HasForeignKey(w => w.BookId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}