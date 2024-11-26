/// Developer : Hector Nuñez Cruz
/// Creation Date : 23/10/2024
/// Creation Description:Aggregate de Solicitud
/// Update Date : 23/10/2024
/// Update Description : --
/// CopyRight: CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.PurchaseRequest
{
    public class PurchaseRequestAggregate
    {
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdBuyer { get; set; }
    }
}

