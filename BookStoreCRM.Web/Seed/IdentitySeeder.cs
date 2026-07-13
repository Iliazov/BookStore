using BookStoreCRM.Domain.Constants;
using BookStoreCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookStoreCRM.Web.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUsers> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            var roles = new[]
            {
                Roles.Admin,
                Roles.Customer,
                Roles.Manager
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole<Guid>
                        {
                            Name = role
                        });
                }
            }

            var adminEmail = "admin@bookstore.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);
            if(admin is null)
            {
                admin = new ApplicationUsers
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "System",
                    LastName = "Administrator",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Admin123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Admin);
                }
            }
        }
    }
}
