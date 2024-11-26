/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 15/10/2024
/// Creation Description : Modelo de peticion
/// Update Date : -
/// Update Description : -
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.DTOs.Product;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock {  get; set; }
    public string Measure { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? ImagenUrl { get; set; }
    public string Status { get; set; }
    public Guid IdSeller { get; set; }
}
