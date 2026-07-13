using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Book;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Category;

namespace BookStoreCRM.Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile() 
        {
            CreateMap<BookDTO, BookItemViewModel>();
            CreateMap<CreateBookViewModel, CreateBookDTO>();
            CreateMap<BookDTO, UpdateBookViewModel>();
            CreateMap<UpdateBookViewModel, UpdateBookDTO>();

            CreateMap<CategoryDTO, CategoryViewModel>();
            CreateMap<CreateCategoryViewModel, CreateCategoryDTO>();
            CreateMap<CategoryDTO, UpdateCategoryViewModel>();
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDTO>();
        }
    }
}
