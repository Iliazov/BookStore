namespace BookStoreCRM.Web.Areas.Admin.ViewModels.User
{
    public class UserDetailsViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public bool IsBlocked { get; set; }
    }
}
