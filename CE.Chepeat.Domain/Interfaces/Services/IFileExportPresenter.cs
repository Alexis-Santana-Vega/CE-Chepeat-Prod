namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IFileExportPresenter
{
    Task<byte[]> ExportToCsvProductsBySeller(Guid idSeller);
    Task<byte[]> ExportToExcelProductsBySeller(Guid idSeller);
    Task<byte[]> ExportToCsvSalesHistoryBySeller(Guid idSeller);
    Task<byte[]> ExportToExcelSalesHistoryBySeller(Guid idSeller);
}
