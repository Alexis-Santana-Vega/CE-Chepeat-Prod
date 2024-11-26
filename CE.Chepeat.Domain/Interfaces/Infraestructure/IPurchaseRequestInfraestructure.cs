
using CE.Chepeat.Domain.Aggregates.PurchaseRequest;
using CE.Chepeat.Domain.DTOs.Product;
using CE.Chepeat.Domain.DTOs.PurchaseRequest;

/// Developer : Hector Nuñez Cruz
/// Creation Date : 23/10/2024
/// Creation Description:Interfaz de Solicitud
/// Update Date : 23/10/2024
/// Update Description : --
/// CopyRight: Chepeat
namespace CE.Chepeat.Domain.Interfaces.Infraestructure
{
    public interface IPurchaseRequestInfraestructure
    {
        Task<PurchaseRequestDto> GetRequestById(Guid id);
        Task<List<PurchaseRequestDto>> GetRequestsByProduct(Guid id);
        /// <summary>
        /// Solicitud de compra
        /// </summary>
        Task<RespuestaDB> CreatePurchaseRequest(PurchaseRequestAggregate request);
        /// <summary>
        /// Mostrar solicitud - Vendedor
        /// </summary>
        Task<List<PurchaseRequestDto>> GetRequestsBySeller(Guid idSeller);
        /// <summary>
        ///Mostrar solicitud - Comprador
        /// </summary>
        Task<List<PurchaseRequestDto>> GetRequestsByBuyer(Guid idBuyer);
        /// <summary>
        /// Rechazar solicitud
        /// </summary>
        Task<RespuestaDB> RejectRequest(Guid idRequest);
        /// <summary>
        /// Cancelar solicitud
        /// </summary>
        Task<RespuestaDB> CancelRequest(Guid idRequest);
    }
}
