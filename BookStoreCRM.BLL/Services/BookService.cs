using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.BLL.Mapping;
using BookStoreCRM.DAL.UnitOfWork;

namespace BookStoreCRM.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.BooksRepository.GetAllAsync();
            return _mapper.Map<List<BookDTO>>(books);
        }
    }
}
