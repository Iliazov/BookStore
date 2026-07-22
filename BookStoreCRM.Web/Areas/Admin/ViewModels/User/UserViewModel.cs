namespace BookStoreCRM.Web.Areas.Admin.ViewModels.User
{
    public class UserViewModel
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
