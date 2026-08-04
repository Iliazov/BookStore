using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.ToTable(nameof(FriendRequest));
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Status)
                   .IsRequired();

            builder.HasOne(f => f.Sender)
                   .WithMany(u => u.SendFriendRequests)
                   .HasForeignKey(f => f.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Receiver)
                   .WithMany(u => u.ReceivedFriendRequests)
                   .HasForeignKey(f => f.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}