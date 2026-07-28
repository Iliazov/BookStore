using Microsoft.AspNetCore.Mvc;
using BookStoreCRM.Web.Models.Account;
using BookStoreCRM.Domain.Entities;
using BookStoreCRM.Domain.Constants;
using BookStoreCRM.BLL.DTOs.Account;
using BookStoreCRM.BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace BookStoreCRM.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(
            SignInManager<ApplicationUsers> signInManager,
            UserManager<ApplicationUsers> userManager,
            IMapper mapper,
            IAccountService service)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _accountService = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(
                user, model.Password,
                model.RememberMe,
                lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(model);
            }

            if(await _userManager.IsInRoleAsync(user, Roles.Admin) ||
                await _userManager.IsInRoleAsync(user, Roles.Manager))
            {
                return RedirectToAction(
                    "Index",
                    "Dashboard",
                    new { area = "Admin" });
            }

            return RedirectToAction(nameof(Index), "Home");
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var registerDto = _mapper.Map<RegisterDTO>(model);
            var result = await _accountService.RegisterAsync(registerDto);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            await _signInManager.SignInAsync(user!, false);

            return RedirectToAction("Index", "Home");
        }
    }
}
