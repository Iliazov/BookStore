using AutoMapper;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderService orderService,
            IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orderDto = await _orderService.GetAllOrdersAsync();
            var model = _mapper.Map<List<OrderViewMoel>>(orderDto);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetail(Guid id)
        {
            var details = await _orderService.GetOrderDetailsAsync(id);
            var model = _mapper.Map<OrderDetailViewModel>(details);
            return View(model);
        }
    }
}
