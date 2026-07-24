using BookStoreCRM.BLL.DTOs.User;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IUserService
    {
        public Task DeleteAsync(Guid id, string? currentUserId);
        public Task SetBlockedAsync(Guid id, bool blocked, string? currentUserId);
        public Task<List<UserDTO>> GetAllAsync();
        public Task<UserDetailsDTO> GetByIdAsync(Guid id);
        public Task<UpdateUserDTO> GetForUpdateAsync(Guid id);
        public Task UpdateAsync(UpdateUserDTO dto);
    }
}
