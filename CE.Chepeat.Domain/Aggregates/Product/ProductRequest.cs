/// Developer : Hector Nuñez Cruz
/// Creation Date : 20/10/2024
/// Creation Description:DTO de Producto
/// Update Date : 15/10/2024
/// Update Description : Implementacion de validaciones
/// CopyRight: CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Product;

public class ProductRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Nombre requerido")]
    [StringLength(120, ErrorMessage = "Nombre máximo 120 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Descripción requerida")]
    [StringLength(512, ErrorMessage = "Descripción máxima 512 caracteres")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Precio requerido")]
    [Range(0, 9999999.99, ErrorMessage = "Rango de precio de 0 a 9,999,999.99")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock requerido")]
    [Range(0, 10000, ErrorMessage = "Rango de stock de 0 a 10,000")]
    public int Stock {  get; set; }

    [Required(ErrorMessage = "Medida requerida")]
    [StringLength(10, ErrorMessage = "Medida máxima 10 caracteres")]
    public string Measure { get; set; }

    public string? ImagenUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "ID de Vendedor requerido")]
    public Guid IdSeller { get; set; }
}
