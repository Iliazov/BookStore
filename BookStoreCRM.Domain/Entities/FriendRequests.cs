using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreCRM.Domain.Enums;

namespace BookStoreCRM.Domain.Entities
{
    public class FriendRequests: BaseEntity
    {
        public Guid SenderId { get; set; }
        public ApplicationUsers Sender { get; set; } = null!;
        public Guid ReceiverId { get; set; }
        public ApplicationUsers Receiver { get; set; } = null!;
        public FriendRequestStatus Status { get; set; }
        public DateTime CreatedAd { get; set; }
    }
}
