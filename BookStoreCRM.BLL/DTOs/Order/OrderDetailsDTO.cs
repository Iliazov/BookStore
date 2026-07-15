using BookStoreCRM.Domain.Enums;

namespace BookStoreCRM.BLL.DTOs.Order
{
    public class OrderDetailsDTO
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemsDTO> OrderItems { get; set; } = [];
    }
}
