using AutoMapper;
using BookStoreCRM.BLL.DTOs.SubCategory;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Domain.Constants;
using BookStoreCRM.Web.Areas.Admin.ViewModels.SubCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Manager)]
    public class SubCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public SubCategoryController(
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public IActionResult Create(Guid categoryId)
        {
            var model = new SubCategoryFormViewModel
            {
                CategoryId = categoryId
            };
            return View(model);
        }

        public async Task<IActionResult> Create(SubCategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = _mapper.Map<CreateSubCategoryDTO>(model);
            await _subCategoryService.CreateSubCategoryAsync(dto);
            return RedirectToAction("CategoryDetail", "Category", new {id=model.CategoryId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid subCategoryId, Guid categoryId)
        {
            await _subCategoryService.DeleteAsync(subCategoryId);
            return RedirectToAction("CategoryDetail", "Category", new {id = categoryId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var subCategory = await _subCategoryService.GetByIdAsync(id);
            var model = _mapper.Map<SubCategoryViewModel>(subCategory);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = _mapper.Map<SubCategoryDTO>(model);
            await _subCategoryService.UpdateAsync(dto);
            return RedirectToAction("CategoryDetail", "Category", new {id = model.CategoryId});
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategories(Guid categoryId)
        {
            var subCategories = await _subCategoryService.GetByCategoryIdAsync(categoryId);
            var result = subCategories.Select(x => new
            {
                id = x.Id,
                name = x.Name
            });
            return Json(result);
        }
    }
}
