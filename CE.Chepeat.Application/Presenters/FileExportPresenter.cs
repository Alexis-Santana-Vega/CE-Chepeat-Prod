
namespace CE.Chepeat.Application.Presenters;
public class FileExportPresenter : IFileExportPresenter
{
    private readonly IUnitRepository _unitRepository;
    public FileExportPresenter(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }
    public async Task<byte[]> ExportToCsvProductsBySeller(Guid idSeller)
    {
        var data = await _unitRepository.productInfraestructure.GetProductsByIdSeller(idSeller);
        return await _unitRepository.fileExportServiceInfraestructure.ExportToCsvAsync(data);
    }

    public async Task<byte[]> ExportToCsvSalesHistoryBySeller(Guid idSeller)
    {
        var data = await _unitRepository.transactionInfraestructure.GetSalesHistoryBySeller(idSeller);
        return await _unitRepository.fileExportServiceInfraestructure.ExportToCsvAsync(data);
    }

    public async Task<byte[]> ExportToExcelProductsBySeller(Guid idSeller)
    {
        var data = await _unitRepository.productInfraestructure.GetProductsByIdSeller(idSeller);
        return await _unitRepository.fileExportServiceInfraestructure.ExportToExcelAsync(data);
    }

    public async Task<byte[]> ExportToExcelSalesHistoryBySeller(Guid idSeller)
    {
        var data = await _unitRepository.transactionInfraestructure.GetSalesHistoryBySeller(idSeller);
        return await _unitRepository.fileExportServiceInfraestructure.ExportToExcelAsync(data);
    }
}
