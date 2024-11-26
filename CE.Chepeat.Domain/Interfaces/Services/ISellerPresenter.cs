using CE.Chepeat.Domain.Aggregates.Seller;
using CE.Chepeat.Domain.Aggregates.User;

namespace CE.Chepeat.Domain.Interfaces.Services;
public interface ISellerPresenter
{
    Task<SellerResponse> AddSeller(SellerRequest request);
    Task<RespuestaDB> UpdateSeller(SellerRequest request);
    Task<Seller> SelectSellerById(Guid id);
    Task<List<Seller>> SelectSellersByRadius(SellerRadiusRequest request);
    Task<RespuestaDB> DeleteSeller(Guid Id);
    Task<Seller> SelectSellerByIdUser(Guid idUser);
    Task<object> GetSellerDetails(Guid id);
}
