/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 08/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.DTOs;
public class Seller
{
    [Key]
    public Guid Id { get; set; }
    public string StoreName { get; set; }
    public string Description { get; set; }
    public string Street { get; set; }
    public string ExtNumber { get; set; }
    public string IntNumber { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string CP { get; set; }
    public string AddressNotes { get; set; }
    //[JsonIgnore]
    //public Point Location { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public decimal Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid IdUser { get; set; }
}
