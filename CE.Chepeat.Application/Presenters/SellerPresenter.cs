using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Seller;

namespace CE.Chepeat.Application.Presenters;
public class SellerPresenter : ISellerPresenter
{
    private readonly IUnitRepository _unitRepository;

    public SellerPresenter(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<object> GetSellerDetails(Guid id)
    {
        var seller = await _unitRepository.sellerInfraestructure.SelectSellerById(id);
        var comments = await _unitRepository.commentInfraestructure.GetCommentsBySeller(id);
        return new
        {
            Seller = seller,
            Comments = comments
        };
    }

    public async Task<SellerResponse> AddSeller(SellerRequest request)
    {
        var response = await _unitRepository.sellerInfraestructure.AddSeller(request);
        var user = await _unitRepository.authInfraestructure.ObtenerPorId(request.IdUser);
        if (user == null) return new SellerResponse { NumError = 1, Result = "Usuario no encontrado"};
        var seller = await _unitRepository.sellerInfraestructure.SelectSellerById(Guid.Parse(response.Result));
        if (user == null) return new SellerResponse { NumError = 1, Result = "Vendedor no encontrado" };
        return new SellerResponse
        {
            NumError = 0,
            Result = "Vendedor creado con éxito",
            User = user,
            Seller = seller
        };
    }

    public async Task<RespuestaDB> DeleteSeller(Guid Id)
    {
        return await _unitRepository.sellerInfraestructure.DeleteSeller(Id);
    }

    public async Task<Seller> SelectSellerById(Guid id)
    {
        return await _unitRepository.sellerInfraestructure.SelectSellerById(id);
    }

    public async Task<List<Seller>> SelectSellersByRadius(SellerRadiusRequest request)
    {
        return await _unitRepository.sellerInfraestructure.SelectSellersByRadius(request);
    }

    public async Task<RespuestaDB> UpdateSeller(SellerRequest request)
    {
        return await _unitRepository.sellerInfraestructure.UpdateSeller(request);
    }

    public async Task<Seller> SelectSellerByIdUser(Guid idUser)
    {
        return await _unitRepository.sellerInfraestructure.SelectSellerByIdUser(idUser);
    }
}
