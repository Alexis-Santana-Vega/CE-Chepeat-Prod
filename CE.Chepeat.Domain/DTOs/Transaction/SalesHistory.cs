namespace CE.Chepeat.Domain.DTOs.Transaction;

public class SalesHistory
{
    [Key]
    public Guid Id { get; set; }
    public string TransactionDate { get; set; }
    public string ProductName { get; set; }
    public string BuyerName { get; set; }
    public decimal Price { get; set; }
}
