using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreCRM.Web.Models.Books
{
    public class CreateBookViewModel
    {
        [Required]
        [Display(Name = "Book Title")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Desciption")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; } = string.Empty;
        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }
        [Display(Name = "Book Image")]
        public IFormFile? Image { get; set; }
        //public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
