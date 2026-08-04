using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Book
{
    public class BookFormViewModel
    {
        [Required]
        [Display(Name = "Book Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Sub Category")]
        public Guid? SubCategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> SubCategories { get; set; } = new List<SelectListItem>();
    }
}
