using AutoMapper;
using BookStoreCRM.BLL.DTOs.Order;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.BLL.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            var orders = await _unitOfWork.OrdersRepository
                .Get()
                .Include(o => o.Customer)
                .ToListAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDetailsDTO> GetOrderDetailsAsync(Guid id)
        {
            var order = await _unitOfWork.OrdersRepository
                .Get()
                .Where(o => o.Id == id)
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Book)
                .FirstOrDefaultAsync(o => o.Id == id)
                ?? throw new NotFoundException("Order not found.");
           
            return _mapper.Map<OrderDetailsDTO>(order);
        }

    }
}
