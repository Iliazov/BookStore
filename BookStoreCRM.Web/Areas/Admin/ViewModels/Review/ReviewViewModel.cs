namespace BookStoreCRM.Web.Areas.Admin.ViewModels.Review
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal Grade { get; set; }
        public string Comment { get; set; } = string.Empty;

    }
}
