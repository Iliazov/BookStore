using AutoMapper;
using BookStoreCRM.BLL.DTOs.Order;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.BLL.Exceptions;

namespace BookStoreCRM.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.OrdersRepository.GetAllWithCustomerAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDetailsDTO> GetOrderDetailsAsync(Guid id)
        {
            var orders = await _unitOfWork.OrdersRepository.GetAllOrdersWithItemsAsync(id);
            if (orders == null)
            {
                throw new NotFoundException("Order not found.");
            }
            return _mapper.Map<OrderDetailsDTO>(orders);
        }

    }
}
