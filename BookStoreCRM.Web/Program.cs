using System.Threading.Tasks;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.BLL.Mapping;
using BookStoreCRM.BLL.Services;
using BookStoreCRM.DAL.Context;
using BookStoreCRM.DAL.Repositories.Implementation;
using BookStoreCRM.DAL.Repositories.Interfaces;
using BookStoreCRM.DAL.UnitOfWork;
using BookStoreCRM.Domain.Entities;
using BookStoreCRM.Web.Mapping;
using BookStoreCRM.Web.Seed;
using BookStoreCRM.Web.Services;
using BookStoreCRM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<IBooksRepository, BooksRepository>();
            builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            builder.Services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
            builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
            builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();
            builder.Services.AddScoped<IWishlistsRepository, WishlistsRepository>();
            builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFileValidator, FileValidator>();

            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IDashboardService, DashboardService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddAutoMapper(
                _ => { },
                typeof(MappingProfile),
                typeof(WebMappingProfile));
            builder.Services
            .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.SlidingExpiration = true;
            });

            var app = builder.Build();
            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                await IdentitySeeder.SeedAsync(userManager, roleManager);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
