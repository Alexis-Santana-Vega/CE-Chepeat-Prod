
using CE.Chepeat.Domain.Aggregates.Product;
using CE.Chepeat.Domain.DTOs.Product;

namespace CE.Chepeat.Application.Presenters;
public class ProductPresenter : IProductPresenter
{
    private readonly IUnitRepository _unitRepository;

    public ProductPresenter(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }
    public async Task<object> GetProductDetails(Guid id)
    {
        return new 
        {
            Product = await _unitRepository.productInfraestructure.GetProductById(id),
            PurchaseRequests = await _unitRepository.purchaseRequestInfraestructure.GetRequestsByProduct(id)
        };
    }
    /// <summary>
    /// Consulta un registro de la tabla CE_Products
    /// </summary>
    /// <returns></returns>
    public async Task<List<Product>> GetProducts()
    {
        return await _unitRepository.productInfraestructure.GetProducts();
    }
    /// <summary>
    /// Añadir un registro de la tabla CE_Products
    /// </summary>
    /// <returns></returns>

    public async Task<RespuestaDB> AddProduct(ProductRequest request)
    {
        return await _unitRepository.productInfraestructure.AddProduct(request);
    }
    /// <summary>
    /// Borrar un registro de la tabla CE_Products
    /// </summary>
    /// <returns></returns>
    public async Task<RespuestaDB> DeleteProduct(Guid id)
    {
        return await _unitRepository.productInfraestructure.DeleteProduct(id);
    }
    /// <summary>
    /// Actualizar un registro de la tabla CE_Products
    /// </summary>
    /// <returns></returns>
    public async Task<RespuestaDB> UpdateProduct(ProductRequest request)
    {
        return await _unitRepository.productInfraestructure.UpdateProduct(request);
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await _unitRepository.productInfraestructure.GetProductById(id);
    }

    public async Task<List<Product>> GetProductsByIdSeller(Guid id)
    {
        return await _unitRepository.productInfraestructure.GetProductsByIdSeller(id);
    }

    public async Task<List<Product>> GetProductsByRadius(ProductRadiusRequest request)
    {
        return await _unitRepository.productInfraestructure.GetProductsByRadius(request);
    }
}
