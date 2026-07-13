using System.ComponentModel.DataAnnotations;

namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Category
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
