using BookStoreCRM.BLL.DTOs.SubCategory;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface ISubCategoryService
    {
        Task CreateSubCategoryAsync(CreateSubCategoryDTO dto);
        Task DeleteAsync(Guid id);
        Task<List<SubCategoryDTO>> GetByCategoryIdAsync(Guid categoryId);
        Task<SubCategoryDTO> GetByIdAsync(Guid id);
        Task UpdateAsync(SubCategoryDTO dto);
    }
}
