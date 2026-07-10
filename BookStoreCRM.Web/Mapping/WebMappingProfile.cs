using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Book;

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
        }
    }
}
