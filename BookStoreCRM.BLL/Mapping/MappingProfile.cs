using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.BLL.DTOs.Order;
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

            CreateMap<Orders, OrderDTO>()
                .ForMember(
                    dest => dest.Customer,
                    opt => opt.MapFrom(src =>
                    $"{src.Customer.FirstName} {src.Customer.LastName}"));
        }
    }
}
