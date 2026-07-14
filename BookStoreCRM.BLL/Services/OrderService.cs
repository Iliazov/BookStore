using AutoMapper;
using BookStoreCRM.BLL.DTOs.Order;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;

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
    }
}
