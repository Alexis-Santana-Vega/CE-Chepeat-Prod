namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IFileExportServiceInfraestructure
{
    Task<byte[]> ExportToExcelAsync<T>(IEnumerable<T> data);
    Task<byte[]> ExportToCsvAsync<T>(IEnumerable<T> data);
}
