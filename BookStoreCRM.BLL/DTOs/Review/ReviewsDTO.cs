namespace BookStoreCRM.BLL.DTOs.Review
{
    public class ReviewsDTO
    {
        public Guid Id { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal Grade { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
