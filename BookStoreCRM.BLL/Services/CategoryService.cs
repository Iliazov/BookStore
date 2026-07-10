using AutoMapper;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.Repositories.Interfaces;

namespace BookStoreCRM.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(
            ICategoriesRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

    }
}
