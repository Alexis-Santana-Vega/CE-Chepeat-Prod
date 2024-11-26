/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 20/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : 20/10/2024
/// Update Description : Implementacion de validaciones
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Seller;
public class SellerRequest
{
    public Guid Id { get; set; }


    [Required]
    [StringLength(120, ErrorMessage = "NombreTienda máximo 120 caracteres")]
    public string StoreName { get; set; }


    [StringLength(255, ErrorMessage = "Descripción máxima 255 caracteres")]
    public string Description { get; set; }
    
    
    [Required]
    [StringLength(120, ErrorMessage = "Calle máxima 120 caracteres")]
    public string Street { get; set; }
    
    
    [Required]
    [StringLength(6, ErrorMessage = "NúmeroExterior máximo 6 números")]
    public string ExtNumber { get; set; }
    
    
    [StringLength(6, ErrorMessage = "NúmeroInterior máximo 6 números")]
    public string IntNumber { get; set; }
    
    
    [Required]
    [StringLength(100, ErrorMessage = "Vecindario/Colonia máximo 100 caracteres")]
    public string Neighborhood { get; set; }
    
    
    [Required]
    [StringLength(100, ErrorMessage = "Ciudad máximo 100 caracteres")]
    public string City { get; set; }
    
    
    [Required]
    [StringLength(100, ErrorMessage = "Estado máximo 100 caracteres")]
    public string State { get; set; }
    
    
    [Required]
    [StringLength(10, ErrorMessage = "CodigoPostal máximo 10 números")]
    public string CP { get; set; }
    
    
    [StringLength(255, ErrorMessage = "DirecciónNotas máximo 255 caracteres")]
    public string AddressNotes { get; set; }
    
    
    [Required]
    public double Latitude { get; set; }
    
    
    [Required]
    public double Longitude { get; set; }


    public Guid IdUser { get; set; } = Guid.Empty;
}
