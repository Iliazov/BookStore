using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.Exceptions;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.Domain.Entities;

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

        public async Task CreateBookAsync(CreateBookDTO bookDTO)
        {
            var book = _mapper.Map<Books>(bookDTO);
            await _unitOfWork.BooksRepository.AddAsync(book);
            await _unitOfWork.Save();
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.BooksRepository.GetAllAsync();
            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO?> GetBookByIdAsync(Guid id)
        {
            var book = await _unitOfWork.BooksRepository.GetByIdAsync(id);
            if (book == null)
                throw new NotFoundException($"Book with id: {id} not found");
            return _mapper.Map<BookDTO>(book);
        }

        public async Task UpdateBookAsync(UpdateBookDTO bookDTO)
        {
            var book = await _unitOfWork.BooksRepository.GetByIdAsync(bookDTO.Id);
            if (book == null)
                throw new NotFoundException($"Book with id: {bookDTO.Id} not found");
            _mapper.Map(bookDTO, book);
            await _unitOfWork.Save();
        }
    }
}
