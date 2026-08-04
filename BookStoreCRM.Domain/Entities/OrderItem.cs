namespace BookStoreCRM.Domain.Entities
{
    public class OrderItem: BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
