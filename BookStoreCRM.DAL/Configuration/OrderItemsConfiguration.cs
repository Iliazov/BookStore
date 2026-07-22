using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable(nameof(OrderItems));
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.Book)
                   .WithMany(b => b.OrderItems)
                   .HasForeignKey(oi => oi.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
