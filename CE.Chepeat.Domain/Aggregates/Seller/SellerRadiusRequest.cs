/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 20/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : 20/10/2024
/// Update Description : Implementacion de validaciones
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Seller;
public class SellerRadiusRequest
{
    [Required]
    public float Latitude { get; set; }


    [Required]
    public float Longitude { get; set; }

    [Required]
    public float RadiusKm { get; set; }
}
