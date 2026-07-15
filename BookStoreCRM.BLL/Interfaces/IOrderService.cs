using BookStoreCRM.BLL.DTOs.Order;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDetailsDTO> GetOrderDetailsAsync(Guid id);
    }
}
