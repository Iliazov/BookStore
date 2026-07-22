using BookStoreCRM.BLL.DTOs.Dashboard;

namespace BookStoreCRM.BLL.Interfaces;

public interface IDashboardService
{
    Task<DashboardDTO> GetDashboardAsync();
}
