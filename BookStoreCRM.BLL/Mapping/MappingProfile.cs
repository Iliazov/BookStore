using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.BLL.DTOs.Order;
using BookStoreCRM.BLL.DTOs.Review;
using BookStoreCRM.BLL.DTOs.User;
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
            CreateMap<Books, BookDetailsDTO>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name)
                );

            CreateMap<Categories, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Categories>();
            CreateMap<UpdateCategoryDTO, Categories>();

            CreateMap<Orders, OrderDTO>()
                .ForMember(
                    dest => dest.CustomerName,
                    opt => opt.MapFrom(src =>
                    $"{src.Customer.FirstName} {src.Customer.LastName}"));

            CreateMap<Orders, OrderDetailsDTO>()
                .ForMember(
                    dest => dest.CustomerName,
                    opt => opt.MapFrom(src =>
                        $"{src.Customer.FirstName} {src.Customer.LastName}"
                    )
                );
            CreateMap<OrderItems, OrderItemsDTO>()
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(src => src.Book.ImageUrl))
                .ForMember(
                    dest => dest.Book,
                    opt => opt.MapFrom(src => src.Book.Title));

            CreateMap<Reviews, ReviewsDTO>()
                .ForMember(
                    dest => dest.CustomerName,
                    opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}")
                )
                .ForMember(
                    dest => dest.BookTitle,
                    opt => opt.MapFrom(src => src.Book.Title)
                );
            CreateMap<Reviews, ReviewDetailsDTO>()
                .ForMember(
                    dest => dest.CustomerName,
                    opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}")
                )
                .ForMember(
                    dest => dest.BookTitle,
                    opt => opt.MapFrom(src => src.Book.Title)
                )
                .ForMember(
                    dest => dest.BookImage,
                    opt => opt.MapFrom(src => src.Book.ImageUrl));

            CreateMap<ApplicationUsers, UserDTO>();
            CreateMap<ApplicationUsers, UserDetailsDTO>();
            CreateMap<ApplicationUsers, UpdateUserDTO>();

        }
    }
}
