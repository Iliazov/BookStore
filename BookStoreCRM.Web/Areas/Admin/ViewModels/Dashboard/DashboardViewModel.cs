using BookStoreCRM.Web.Areas.Admin.ViewModels.Order;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Review;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Dashboard;

public class DashboardViewModel
{
    public int BooksCount { get; set; }
    public int CategoriesCount { get; set; }
    public int OrdersCount { get; set; }
    public int ReviewsCount { get; set; }
    public decimal TotalOrderValue { get; set; }
    public List<OrderViewMoel> RecentOrders { get; set; } = [];
    public List<ReviewViewModel> RecentReviews { get; set; } = [];
}
