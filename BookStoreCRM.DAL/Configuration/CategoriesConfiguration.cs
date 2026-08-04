using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            builder.HasMany(c => c.SubCategories)
                   .WithOne(b => b.Category)
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
