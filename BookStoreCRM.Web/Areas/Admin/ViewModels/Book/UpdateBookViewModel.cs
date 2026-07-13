using System.ComponentModel.DataAnnotations;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Book
{
    public class UpdateBookViewModel : BookFormViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Book Image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "New Book Image")]

        public IFormFile? NewImageUrl { get; set; }

    }
}
