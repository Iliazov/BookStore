using BookStoreCRM.Domain.Enums;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Order
{
    public class OrderDetailViewModel
    {
        public Guid Id { get; set; }
        public string CustomerName {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemsViewModel> OrderItems { get; set; } = [];
    }
}
