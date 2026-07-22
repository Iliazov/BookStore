using BookStoreCRM.BLL.DTOs.User;

namespace BookStoreCRM.BLL.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllAsync();
        public Task<UserDetailsDTO> GetByIdAsync(Guid id);
        public Task<UpdateUserDTO> GetForUpdateAsync(Guid id);
        public Task UpdateAsync(UpdateUserDTO dto);
    }
}
