using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalPrice)
                   .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Status)
                   .IsRequired();

            builder.HasOne(o => o.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}