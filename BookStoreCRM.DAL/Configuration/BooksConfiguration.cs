using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class BooksConfiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.ToTable(nameof(Books));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title)
                   .IsRequired();

            builder.Property(b => b.Description)
                   .IsRequired();

            builder.Property(b => b.Author)
                   .IsRequired();

            builder.Property(b => b.Price)
                    .HasColumnType("decimal(18,2)");

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}