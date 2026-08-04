using AutoMapper;
using BookStoreCRM.BLL.DTOs.Account;
using BookStoreCRM.BLL.DTOs.Book;
using BookStoreCRM.BLL.DTOs.Category;
using BookStoreCRM.BLL.DTOs.Dashboard;
using BookStoreCRM.BLL.DTOs.Order;
using BookStoreCRM.BLL.DTOs.Review;
using BookStoreCRM.BLL.DTOs.SubCategory;
using BookStoreCRM.BLL.DTOs.User;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Book;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Category;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Dashboard;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Order;
using BookStoreCRM.Web.Areas.Admin.ViewModels.Review;
using BookStoreCRM.Web.Areas.Admin.ViewModels.SubCategory;
using BookStoreCRM.Web.Areas.Admin.ViewModels.User;
using BookStoreCRM.Web.Models.Account;

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
            CreateMap<BookDetailsDTO, BookDetailsViewModel>();

            CreateMap<CategoryDTO, CategoryViewModel>();
            CreateMap<CreateCategoryViewModel, CreateCategoryDTO>();
            CreateMap<CategoryDTO, UpdateCategoryViewModel>();
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDTO>();
            CreateMap<CategoryWithSubCategoryDTO, CategoryWithSubCategoryViewModel>();

            CreateMap<SubCategoryFormViewModel, CreateSubCategoryDTO>();
            CreateMap<SubCategoryDTO, SubCategoryViewModel>();
            CreateMap<SubCategoryViewModel, SubCategoryDTO>();

            CreateMap<RegisterViewModel, RegisterDTO>();

            CreateMap<OrderDTO, OrderViewMoel>();
            CreateMap<OrderDetailsDTO, OrderDetailViewModel>();
            CreateMap<OrderItemsDTO, OrderItemsViewModel>();

            CreateMap<ReviewsDTO, ReviewViewModel>();
            CreateMap<ReviewDetailsDTO, ReviewDetailsViewModel>();

            CreateMap<DashboardDTO, DashboardViewModel>();

            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserDetailsDTO, UserDetailsViewModel>();
            CreateMap<UpdateUserDTO, UpdateUserVeiwModel>();
            CreateMap<UpdateUserVeiwModel, UpdateUserDTO>();
        }
    }
}
