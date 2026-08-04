using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Domain.Constants;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Book;
using BookStoreCRM.Web.Constants;
using BookStoreCRM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreCRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin+","+Roles.Manager)]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IFileValidator _fileValidator;
        public BookController(
            IBookService bookService,
            IMapper mapper,
            IFileService fileService,
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IFileValidator fileValidator)
        {
            _bookService = bookService;
            _mapper = mapper;
            _fileService = fileService;
            _categoryService = categoryService;
            _fileValidator = fileValidator;
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            var model = new CreateBookViewModel();
            await LoadCategories(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            var model = _mapper.Map<List<BookItemViewModel>>(books);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookDetail(Guid id)
        {
            var bookDTO = await _bookService.GetBookWithCategoryAsync(id);
            var model = _mapper.Map<BookDetailsViewModel>(bookDTO);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            var file = model.Image;
            
            if (!_fileValidator.Validate(file, nameof(model.Image), ModelState))
            {
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                await LoadCategories(model);
                return View(model);
            }

            string? imagePath = null;

            if (file is not null)
            {
                using var stream = file.OpenReadStream();
                imagePath = await _fileService.UploadFile(stream, file.FileName, FileConstants.Books);
                
            }

            var book = _mapper.Map<CreateBookDTO>(model);
            book.ImageUrl = imagePath;
            await _bookService.CreateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var bookDto = await _bookService.GetBookByIdAsync(id);

            if (bookDto == null)
                return NotFound();

            var model = _mapper.Map<UpdateBookViewModel>(bookDto);
            await LoadCategories(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategories(model);
           
                return View(model);
            }

            if (model.NewImageUrl is not null)
            {
                if(!_fileValidator.Validate(
                    model.NewImageUrl,
                    nameof(model.NewImageUrl), 
                    ModelState))
                {
                    return View(model);
                }

                await _fileService.DeleteAsync(model.ImageUrl);

                using var stream = model.NewImageUrl.OpenReadStream();

                model.ImageUrl = await _fileService.UploadFile(
                    stream,
                    model.NewImageUrl.FileName,
                    FileConstants.Books);
            }
           
            var bookDto = _mapper.Map<UpdateBookDTO>(model);
            await _bookService.UpdateBookAsync(bookDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var book = await _bookService.GetBookByIdAsync(Id);
            if (book == null)
            {
                return NotFound();
            }
            await _fileService.DeleteAsync(book.ImageUrl);
            await _bookService.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCategories(BookFormViewModel model)
        {
            var categories = await _categoryService.GetCategoriesAsync();
            model.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            model.SubCategories = new List<SelectListItem>();
            if(model.CategoryId != Guid.Empty)
            {
                var subCategories = await _subCategoryService.GetByCategoryIdAsync(model.CategoryId);
                model.SubCategories = subCategories.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList();
            }
        }
    }
}
