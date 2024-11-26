/// Developer : Hector Nuñez Cruz
/// Creation Date : 20/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.DTOs.PurchaseRequest
{
    public class PurchaseRequestDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdBuyer { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public string BuyerName { get; set; }
    }
}

