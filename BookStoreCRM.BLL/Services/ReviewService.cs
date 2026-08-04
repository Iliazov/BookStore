using AutoMapper;
using BookStoreCRM.BLL.DTOs.Review;
using BookStoreCRM.BLL.Exceptions;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReviewService(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Review review)
        {
            _unitOfWork.ReviewsRepository.Delete(review);
            await _unitOfWork.Save();
        }

        public Task<Review?> GetByIdAsync(Guid id)
        {
            return _unitOfWork.ReviewsRepository.GetByIdAsync(id);
        }

        public async Task<ReviewDetailsDTO> GetReviewDetailsAsync(Guid id)
        {
            var review = await _unitOfWork.ReviewsRepository
                .Get()
                .Where(r => r.Id == id)
                .Include(r => r.User)
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.Id == id);
            
            return review == null
                ? throw new NotFoundException("d")
                : _mapper.Map<ReviewDetailsDTO>(review);
        }

        public async Task<List<ReviewsDTO>> GetReviewsAsync()
        {
            var reviews = await _unitOfWork.ReviewsRepository
                .Get()
                .Include(r => r.User)
                .Include(r => r.Book)
                .ToListAsync();

            return _mapper.Map<List<ReviewsDTO>>(reviews);
        }
    }
}
