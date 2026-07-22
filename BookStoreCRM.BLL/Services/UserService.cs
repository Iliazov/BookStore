using AutoMapper;
using BookStoreCRM.BLL.DTOs.User;
using BookStoreCRM.BLL.Interfaces;
using BookStoreCRM.BLL.Exceptions;
using BookStoreCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCRM.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public UserService(
            IMapper mapper,
            UserManager<ApplicationUsers> userManager,
            RoleManager<IdentityRole<Guid>> roleManager) 
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _userManager.Users.AsNoTracking().ToListAsync();
            var result = new List<UserDTO>();
            foreach (var user in users)
            {
                var dto = _mapper.Map<UserDTO>(user);
                var roles = await _userManager.GetRolesAsync(user);
                dto.Role = roles.FirstOrDefault() ?? string.Empty;
                dto.IsBlocked = await _userManager.IsLockedOutAsync(user);
                result.Add(dto);
            }
            return result;
        }

        public async Task<UserDetailsDTO> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user is null)
            {
                throw new NotFoundException("User not found!");
            }
            var dto = _mapper.Map<UserDetailsDTO>(user);
            var roles = await _userManager.GetRolesAsync(user);
            dto.Role = roles.FirstOrDefault() ?? string.Empty;
            dto.IsBlocked = await _userManager.IsLockedOutAsync(user);

            return dto;
        }

        public async Task<UpdateUserDTO> GetForUpdateAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                throw new NotFoundException("User not found!");
            }

            var dto = _mapper.Map<UpdateUserDTO>(user);
            var role = await _userManager.GetRolesAsync(user);
            dto.Role = role.FirstOrDefault() ?? string.Empty;
            dto.EmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            return dto;
        }

        public async Task UpdateAsync(UpdateUserDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName) ||
                string.IsNullOrWhiteSpace(dto.LastName) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Role))
            {
                throw new ValidationException(
                    "First name, last name, email and role are required.");
            }

            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            if (user is null)
            {
                throw new NotFoundException("User not found!");
            }

            if (!await _roleManager.RoleExistsAsync(dto.Role))
            {
                throw new ValidationException($"Role '{dto.Role}' does not exist.");
            }

            var email = dto.Email.Trim();
            var userWithEmail = await _userManager.FindByEmailAsync(email);
            if (userWithEmail is not null && userWithEmail.Id != user.Id)
            {
                throw new ConflictException("A user with this email already exists.");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var changesAdminRole = currentRoles.Contains(
                BookStoreCRM.Domain.Constants.Roles.Admin,
                StringComparer.OrdinalIgnoreCase) &&
                !string.Equals(
                    dto.Role,
                    BookStoreCRM.Domain.Constants.Roles.Admin,
                    StringComparison.OrdinalIgnoreCase);

            if (changesAdminRole)
            {
                var administrators = await _userManager.GetUsersInRoleAsync(
                    BookStoreCRM.Domain.Constants.Roles.Admin);

                if (administrators.Count <= 1)
                {
                    throw new ConflictException(
                        "The role of the last administrator cannot be changed.");
                }
            }

            user.FirstName = dto.FirstName.Trim();
            user.LastName = dto.LastName.Trim();
            user.Email = email;
            user.UserName = email;
            user.PhoneNumber = string.IsNullOrWhiteSpace(dto.PhoneNumber)
                ? null
                : dto.PhoneNumber.Trim();
            user.EmailConfirmed = dto.EmailConfirmed;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new ValidationException(string.Join(
                    " ",
                    updateResult.Errors.Select(error => error.Description)));
            }

            var hasSelectedRole = currentRoles.Any(role =>
                string.Equals(role, dto.Role, StringComparison.OrdinalIgnoreCase));

            if (!hasSelectedRole)
            {
                var addRoleResult = await _userManager.AddToRoleAsync(user, dto.Role);
                if (!addRoleResult.Succeeded)
                {
                    throw new ValidationException(string.Join(
                        " ",
                        addRoleResult.Errors.Select(error => error.Description)));
                }
            }

            var rolesToRemove = currentRoles
                .Where(role => !string.Equals(
                    role,
                    dto.Role,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (rolesToRemove.Count > 0)
            {
                var removeRolesResult = await _userManager.RemoveFromRolesAsync(
                    user,
                    rolesToRemove);

                if (!removeRolesResult.Succeeded)
                {
                    throw new ValidationException(string.Join(
                        " ",
                        removeRolesResult.Errors.Select(error => error.Description)));
                }
            }
        }
    }
}
