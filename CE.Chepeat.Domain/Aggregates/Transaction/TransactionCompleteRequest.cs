/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 05/11/2024
/// Creation Description : Modelo de peticion
/// Update Date : 05/11/2024
/// Update Description : Implementacion de validaciones
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Transaction;
public class TransactionCompleteRequest
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public bool WasDelivered { get; set; }
    [Required]
    public bool WasPaid { get; set; }
}
