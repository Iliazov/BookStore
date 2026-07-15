
using BookStoreCRM.BLL.DTOs.Review;
using BookStoreCRM.Domain.Entities;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IReviewService
    {
        Task DeleteAsync(Reviews review);
        Task<Reviews?> GetByIdAsync(Guid id);
        Task<ReviewDetailsDTO> GetReviewDetailsAsync(Guid id);
        Task<List<ReviewsDTO>> GetReviewsAsync();
    }
}
