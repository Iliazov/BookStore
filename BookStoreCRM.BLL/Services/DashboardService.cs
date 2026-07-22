using BookStoreCRM.BLL.DTOs.Dashboard;
using BookStoreCRM.BLL.Interfaces;

namespace BookStoreCRM.BLL.Services;

public class DashboardService : IDashboardService
{
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;
    private readonly IOrderService _orderService;
    private readonly IReviewService _reviewService;

    public DashboardService(
        IBookService bookService,
        ICategoryService categoryService,
        IOrderService orderService,
        IReviewService reviewService)
    {
        _bookService = bookService;
        _categoryService = categoryService;
        _orderService = orderService;
        _reviewService = reviewService;
    }

    public async Task<DashboardDTO> GetDashboardAsync()
    {
        var books = await _bookService.GetAllBooksAsync();
        var categories = await _categoryService.GetCategoriesAsync();
        var orders = await _orderService.GetAllOrdersAsync();
        var reviews = await _reviewService.GetReviewsAsync();

        return new DashboardDTO
        {
            BooksCount = books.Count,
            CategoriesCount = categories.Count,
            OrdersCount = orders.Count,
            ReviewsCount = reviews.Count,
            TotalOrderValue = orders.Sum(order => order.TotalPrice),
            RecentOrders = orders
                .OrderByDescending(order => order.CreatedAt)
                .Take(5)
                .ToList(),
            RecentReviews = reviews
                .Take(5)
                .ToList()
        };
    }
}
