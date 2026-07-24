using AutoMapper;
using BookStoreCRM.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.Web.Areas.Admin.ViewModels.User;
using BookStoreCRM.BLL.DTOs.User;
using System.Security.Claims;

namespace BookStoreCRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            var model = _mapper.Map<List<UserViewModel>>(users);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetail(Guid id)
        {
            var userById = await _userService.GetByIdAsync(id);
            var model = _mapper.Map<UserDetailsViewModel>(userById);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetForUpdateAsync(id);
            var model = _mapper.Map<UpdateUserVeiwModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserVeiwModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = _mapper.Map<UpdateUserDTO>(model);
            await _userService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if(user is null)
            {
                return NotFound();
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _userService.DeleteAsync(id, currentUserId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SetBlocked(Guid id, bool isBlocked)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _userService.SetBlockedAsync(id, isBlocked, currentUserId);
            TempData["SuccessMessage"] = isBlocked
             ? "User successfully blocked."
             : "User successfully unblocked.";
            return RedirectToAction(nameof(UserDetail), new {id});
        }
    }
}
