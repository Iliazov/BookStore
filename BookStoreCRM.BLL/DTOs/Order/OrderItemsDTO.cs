namespace BookStoreCRM.BLL.DTOs.Order
{
    public class OrderItemsDTO
    {
        public string Image { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Book { get; set; } = string.Empty;
        public Guid BookId { get; set; }
    }
}
