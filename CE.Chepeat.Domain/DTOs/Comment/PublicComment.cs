namespace CE.Chepeat.Domain.DTOs.Comment;
public class PublicComment
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public decimal Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public string BuyerName { get; set; }
    public string SellerName { get; set; }
}
