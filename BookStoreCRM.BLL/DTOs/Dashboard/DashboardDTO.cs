using BookStoreCRM.BLL.DTOs.Order;
using BookStoreCRM.BLL.DTOs.Review;

namespace BookStoreCRM.BLL.DTOs.Dashboard;

public class DashboardDTO
{
    public int BooksCount { get; set; }
    public int CategoriesCount { get; set; }
    public int OrdersCount { get; set; }
    public int ReviewsCount { get; set; }
    public decimal TotalOrderValue { get; set; }
    public List<OrderDTO> RecentOrders { get; set; } = [];
    public List<ReviewsDTO> RecentReviews { get; set; } = [];
}
