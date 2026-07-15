namespace BookStoreCRM.BLL.DTOs.Review
{
    public class ReviewDetailsDTO
    {
        public string BookImage { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public decimal Grade { get; set; }
    }
}
