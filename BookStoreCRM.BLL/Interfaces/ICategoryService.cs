using BookStoreCRM.BLL.DTOs.Category;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<(List<CategoryDTO> Categories, int totalCount)> GetCategoriesAsync(int? page, int? pageSize);
        Task CreateAsync(CreateCategoryDTO categoryDTO);
        Task<CategoryDTO?> GetByIdAsync(Guid id);
        Task UpdateAsync(UpdateCategoryDTO categoryDTO);
        Task DeleteAsync(Guid id);
        Task<CategoryWithSubCategoryDTO> GetWithSubCategoryByIdAsync(Guid id);
        Task<List<CategoryDTO>> GetCategoriesAsync();
    }
}
