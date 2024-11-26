/// Developer : Hector Nuñez Cruz
/// Creation Date : 20/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.DTOs.Transaction
{
    public class TransactionDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdPurchaseRequest { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public string BuyerName { get; set; }
    }
}