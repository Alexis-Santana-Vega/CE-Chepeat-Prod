/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 25/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : 25/10/2024
/// Update Description : Implementacion de User y Seller
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Seller;
public class SellerResponse
{
    public int NumError { get; set; }
    public string Result { get; set; }
    public DTOs.Seller? Seller { get; set; } = null;
    public DTOs.User? User { get; set; } = null;
}
