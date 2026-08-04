using Microsoft.AspNetCore.Identity;

namespace BookStoreCRM.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Avatar {get; set;}

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public ICollection<FriendRequest> SendFriendRequests { get; set; } = new List<FriendRequest>();
        public ICollection<FriendRequest> ReceivedFriendRequests { get; set; } = new List<FriendRequest>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
