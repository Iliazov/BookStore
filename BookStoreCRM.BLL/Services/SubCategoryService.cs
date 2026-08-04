using AutoMapper;
using BookStoreCRM.BLL.DTOs.SubCategory;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.Domain.Entities;
using BookStoreCRM.BLL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.BLL.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateSubCategoryAsync(CreateSubCategoryDTO dto)
        {
            var subCategory = _mapper.Map<SubCategory>(dto);
            await _unitOfWork.SubCategoryRepository.AddAsync(subCategory);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(Guid id)
        {
            var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Sub category not found");

            _unitOfWork.SubCategoryRepository.Delete(subCategory);
            await _unitOfWork.Save();
        }

        public async Task<List<SubCategoryDTO>> GetByCategoryIdAsync(Guid categoryId)
        {
            var subCategories = await _unitOfWork.SubCategoryRepository
                .Get()
                .Where(s => s.CategoryId == categoryId)
                .ToListAsync();

            return _mapper.Map<List<SubCategoryDTO>>(subCategories);

        }

        public async Task<SubCategoryDTO> GetByIdAsync(Guid id)
        {
            var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Sub Category not found");
            return _mapper.Map<SubCategoryDTO>(subCategory);
        }

        public async Task UpdateAsync(SubCategoryDTO dto)
        {
            var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(dto.Id)
                ?? throw new NotFoundException("Sub Category not found.");
            _mapper.Map(dto, subCategory);
            await _unitOfWork.Save();
        }
    }
}
