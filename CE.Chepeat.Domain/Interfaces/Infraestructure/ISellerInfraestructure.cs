using CE.Chepeat.Domain.Aggregates.Seller;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface ISellerInfraestructure
{
    Task<RespuestaDB> AddSeller(SellerRequest request);
    Task<RespuestaDB> UpdateSeller(SellerRequest request);
    Task<Seller> SelectSellerById(Guid id);
    Task<List<Seller>> SelectSellersByRadius(SellerRadiusRequest request);
    Task<RespuestaDB> DeleteSeller(Guid Id);
    Task<Seller> SelectSellerByIdUser(Guid idUser);
}
