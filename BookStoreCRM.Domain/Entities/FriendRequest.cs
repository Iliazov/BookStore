using BookStoreCRM.Domain.Enums;

namespace BookStoreCRM.Domain.Entities
{
    public class FriendRequest: BaseEntity
    {
        public Guid SenderId { get; set; }
        public ApplicationUser Sender { get; set; } = null!;
        public Guid ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; } = null!;
        public FriendRequestStatus Status { get; set; }
        public DateTime CreatedAd { get; set; }
    }
}
