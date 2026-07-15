namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Review
{
    public class ReviewDetailsViewModel
    {
        public string BookImage { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public decimal Grade { get; set; }
    }
}
