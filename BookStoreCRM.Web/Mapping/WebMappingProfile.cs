using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.Web.Models.Books;

namespace BookStoreCRM.Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile() 
        {
            CreateMap<BookDTO, BookItemViewModel>();
        }
    }
}
