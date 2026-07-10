using BookStoreCRM.BLL.DTOs.Category;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategoriesAsync();
    }
}
