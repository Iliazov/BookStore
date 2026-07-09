using System.Threading.Tasks;
using AutoMapper;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Web.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(
            IBookService bookService,
            IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateBookViewModel();
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
        public IActionResult Create(CreateBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
