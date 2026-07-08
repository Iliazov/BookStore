using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreCRM.Domain.Entities
{
    public class Wishlists : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUsers User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Books Book { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
