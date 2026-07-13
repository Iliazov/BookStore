using System.ComponentModel.DataAnnotations;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Book
{
    public class CreateBookViewModel : BookFormViewModel
    {
        [Display(Name = "Book Image")]
        public IFormFile? Image { get; set; }
    }
}
