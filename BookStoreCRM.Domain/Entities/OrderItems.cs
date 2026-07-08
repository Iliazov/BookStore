using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreCRM.Domain.Entities
{
    public class OrderItems: BaseEntity
    {
        public Guid OrderId { get; set; }
        public Orders Order { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid BookId { get; set; }
        public Books Book { get; set; } = null!;
    }
}
