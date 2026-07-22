namespace BookStoreCRM.BLL.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
    }
}
