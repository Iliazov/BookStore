using AutoMapper;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Domain.Constants;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Manager)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryService categoryService, 
            IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 5;
            page = page < 1 ? 1 : page;
            var categories = await _categoryService.GetCategoriesAsync(page, pageSize);
            var model = new CategoryIndexViewModel
            {
                Categories = _mapper.Map<List<CategoryViewModel>>(categories.Categories),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)categories.totalCount / pageSize),
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryDetail(Guid id)
        {
            var category = await _categoryService.GetWithSubCategoryByIdAsync(id);
            var model = _mapper.Map<CategoryWithSubCategoryViewModel>(category);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateCategoryViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = _mapper.Map<CreateCategoryDTO>(model);
            await _categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<UpdateCategoryViewModel>(category);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var categoryDto = _mapper.Map<UpdateCategoryDTO>(model);
            await _categoryService.UpdateAsync(categoryDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
