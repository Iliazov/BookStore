using AutoMapper;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Domain.Constants;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Manager)]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(
            IReviewService reviewService, 
            IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reviewDto = await _reviewService.GetReviewsAsync();
            var model = _mapper.Map<List<ReviewViewModel>>(reviewDto);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ReviewDetail(Guid id)
        {
            var detailsDto = await _reviewService.GetReviewDetailsAsync(id);
            var model = _mapper.Map<ReviewDetailsViewModel>(detailsDto);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            await _reviewService.DeleteAsync(review);
            return RedirectToAction(nameof(Index));
        }
    }
}
