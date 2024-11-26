using CE.Chepeat.Domain.Aggregates.PurchaseRequest;
using CE.Chepeat.Domain.DTOs.PurchaseRequest;

/// Developer : Hector Nuñez Cruz
/// Creation Date : 23/10/2024
/// Creation Description: Presenter de Solicitud
/// Update Date : 23/10/2024
/// Update Description : Implementación de métodos faltantes
/// CopyRight: Chepeat

namespace CE.Chepeat.Application.Presenters
{
    public class PurchaseRequestPresenter : IPurchaseRequestPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public PurchaseRequestPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<PurchaseRequestDto> GetRequestById(Guid id)
        {
            return await _unitRepository.purchaseRequestInfraestructure.GetRequestById(id);
        }

        public async Task<List<PurchaseRequestDto>> GetRequestsByProduct(Guid id)
        {
            return await _unitRepository.purchaseRequestInfraestructure.GetRequestsByProduct(id);
        }

        public async Task<RespuestaDB> CreatePurchaseRequest(PurchaseRequestAggregate request)
        {
            return await _unitRepository.purchaseRequestInfraestructure.CreatePurchaseRequest(request);
        }

        public async Task<List<PurchaseRequestDto>> GetRequestsBySeller(Guid idSeller)
        {
            return await _unitRepository.purchaseRequestInfraestructure.GetRequestsBySeller(idSeller);
        }

        public async Task<List<PurchaseRequestDto>> GetRequestsByBuyer(Guid idBuyer)
        {
            return await _unitRepository.purchaseRequestInfraestructure.GetRequestsByBuyer(idBuyer);
        }

        public async Task<RespuestaDB> RejectRequest(Guid idRequest)
        {
            return await _unitRepository.purchaseRequestInfraestructure.RejectRequest(idRequest);
        }

        public async Task<RespuestaDB> CancelRequest(Guid idRequest)
        {
            return await _unitRepository.purchaseRequestInfraestructure.CancelRequest(idRequest);
        }
    }
}