using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.Domain.Entities;
namespace BookStoreCRM.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Books, BookDTO>();
            CreateMap<CreateBookDTO, Books>();
            CreateMap<UpdateBookDTO, Books>();

            CreateMap<Categories, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Categories>();
            CreateMap<UpdateCategoryDTO, Categories>();
        }
    }
}
