using AutoMapper;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.Domain.Entities;
namespace BookStoreCRM.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Books, BookDTO>();
        }
    }
}
