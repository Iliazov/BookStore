using Microsoft.AspNetCore.Identity;

namespace BookStoreCRM.Domain.Entities
{
    public class ApplicationUsers : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Avatar {get; set;}

        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
        public ICollection<Wishlists> Wishlists { get; set; } = new List<Wishlists>();
        public ICollection<FriendRequests> SendFriendRequests { get; set; } = new List<FriendRequests>();
        public ICollection<FriendRequests> ReceivedFriendRequests { get; set; } = new List<FriendRequests>();
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
    }
}
