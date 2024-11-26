using CE.Chepeat.Domain.Aggregates.Product;
using CE.Chepeat.Domain.DTOs.Product;

namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IProductPresenter
{
    public Task<object> GetProductDetails(Guid id);
    /// <summary>
    /// Consulta todos los productos en cierto radio
    /// </summary>
    Task<List<Product>> GetProductsByRadius(ProductRadiusRequest request);

    /// <summary>
    /// Consulta todos los registros de la tabla Products
    /// </summary>
    Task<List<Product>> GetProducts();

    /// <summary>
    /// Crear un registro en Products
    /// </summary>
    Task<RespuestaDB> AddProduct(ProductRequest request);

    /// <summary>
    /// Eliminar un registro de Products
    /// </summary>
    Task<RespuestaDB> DeleteProduct(Guid id);

    /// <summary>
    /// Actualizar un registro de Products
    /// </summary>
    Task<RespuestaDB> UpdateProduct(ProductRequest request);

    Task<Product> GetProductById(Guid id);

    Task<List<Product>> GetProductsByIdSeller(Guid id);
}
