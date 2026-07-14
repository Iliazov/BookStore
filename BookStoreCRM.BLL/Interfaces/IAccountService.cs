using BookStoreCRM.BLL.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO);
    }
}
