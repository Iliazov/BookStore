using BookStoreCRM.Domain.Enums;

namespace BookStoreCRM.Domain.Entities
{
    public class Orders: BaseEntity
    {
        public Guid CustomerId { get; set; }
        public ApplicationUsers Customer { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
