using System.ComponentModel.DataAnnotations;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.User
{
    public class UpdateUserVeiwModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName {  get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Role {  get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string? Avatar { get; set; } = string.Empty;
    }
}
