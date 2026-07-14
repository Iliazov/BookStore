using BookStoreCRM.Domain.Enums;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Order
{
    public class OrderViewMoel
    {
        public Guid Id { get; set; }
        public string Customer { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}
