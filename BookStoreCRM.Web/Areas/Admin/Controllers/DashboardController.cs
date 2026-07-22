using AutoMapper;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Domain.Constants;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = Roles.Admin + "," + Roles.Manager)]
public class DashboardController : Controller
{
    private readonly IDashboardService _dashboardService;
    private readonly IMapper _mapper;

    public DashboardController(
        IDashboardService dashboardService,
        IMapper mapper)
    {
        _dashboardService = dashboardService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var dashboard = await _dashboardService.GetDashboardAsync();
        var model = _mapper.Map<DashboardViewModel>(dashboard);

        return View(model);
    }
}
