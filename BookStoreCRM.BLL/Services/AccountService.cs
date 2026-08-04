using BookStoreCRM.BLL.DTOs.Account;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Domain.Constants;
using BookStoreCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookStoreCRM.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Description = "Email already exists."
                    });
            }
            var user = new ApplicationUser
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return result;
            }
            await _userManager.AddToRoleAsync(user, Roles.Customer);
            return IdentityResult.Success;
        }
    }
}
