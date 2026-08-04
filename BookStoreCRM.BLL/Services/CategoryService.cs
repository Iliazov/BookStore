using AutoMapper;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.BLL.Exceptions;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateCategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Category not found");
            _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.Save();
        }

        public async Task<CategoryDTO?> GetByIdAsync(Guid id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.Get().ToListAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryWithSubCategoryDTO> GetWithSubCategoryByIdAsync(Guid id)
        {
            var category = await _unitOfWork.CategoryRepository
                .Get()
                .Where(c => c.Id == id)
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new NotFoundException("Category not found.");
           
            return _mapper.Map<CategoryWithSubCategoryDTO>(category);
        }

        public async Task UpdateAsync(UpdateCategoryDTO categoryDTO)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryDTO.Id)
                ?? throw new NotFoundException("Category not found!");
            _mapper.Map(categoryDTO, category);
            await _unitOfWork.Save();
        }
    }
}
