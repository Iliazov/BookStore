using BookStoreCRM.Domain.Enums;

namespace BookStoreCRM.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public ApplicationUser Customer { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
