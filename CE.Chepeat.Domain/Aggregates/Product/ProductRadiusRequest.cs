/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 15/10/2024
/// Creation Description : Modelo de petición
/// Update Date : 15/10/2024
/// Update Description : Implementacion de validaciones
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Product;
public class ProductRadiusRequest
{
    [Required]
    public float Latitude { get; set; }


    [Required]
    public float Longitude { get; set; }

    [Required]
    public float RadiusKm { get; set; }
}
