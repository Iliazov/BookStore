using AutoMapper;
using BookStoreCRM.BLL.DTOs.Review;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.Domain.Entities;

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

        public async Task DeleteAsync(Reviews review)
        {
            _unitOfWork.ReviewsRepository.Delete(review);
            await _unitOfWork.Save();
        }

        public Task<Reviews?> GetByIdAsync(Guid id)
        {
            return _unitOfWork.ReviewsRepository.GetByIdAsync(id);
        }

        public async Task<ReviewDetailsDTO> GetReviewDetailsAsync(Guid id)
        {
            var review = await _unitOfWork.ReviewsRepository.GetReviewDetailsAsync(id);
            return _mapper.Map<ReviewDetailsDTO>(review);
        }

        public async Task<List<ReviewsDTO>> GetReviewsAsync()
        {
            var reviews = await _unitOfWork.ReviewsRepository.GetReviewsWithBookAndUser();
            return _mapper.Map<List<ReviewsDTO>>(reviews);
        }
    }
}
