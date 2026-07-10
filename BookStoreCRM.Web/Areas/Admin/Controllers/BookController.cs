using System.Threading.Tasks;
using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Book;
using BookStoreCRM.Web.Constants;
using BookStoreCRM.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreCRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public BookController(
            IBookService bookService,
            IMapper mapper,
            IFileService fileService,
            ICategoryService categoryService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _fileService = fileService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            var model = new CreateBookViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList()
            };
                    
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            var model = _mapper.Map<List<BookItemViewModel>>(books);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            var file = model.Image;
            
            if(file is null || file.Length == 0)
            {
                ModelState.AddModelError(nameof(model.Image), "Please select an image");
            }

            if (file is not null && file.Length > FileConstants.MaxFileSize)
            {
                ModelState.AddModelError(nameof(model.Image), "Maximum file size is 5 MB");
            }

            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetCategoriesAsync();

                model.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                return View(model);
            }

            string? imagePath = null;

            if (file is not null)
            {
                using var stream = file.OpenReadStream();
                imagePath = await _fileService.UploadFile(stream, file.FileName, FileFolders.Books);
                
            }

            var book = _mapper.Map<CreateBookDTO>(model);
            book.ImageUrl = imagePath;
            await _bookService.CreateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var bookDto = await _bookService.GetBookByIdAsync(id);
            if (bookDto == null)
                return NotFound();
            var model = _mapper.Map<UpdateBookViewModel>(bookDto);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var bookDto = _mapper.Map<UpdateBookDTO>(model);
            await _bookService.UpdateBookAsync(bookDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
