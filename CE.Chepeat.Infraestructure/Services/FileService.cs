using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using ClosedXML.Excel;

namespace CE.Chepeat.Infraestructure.Services;

public class FileService : IFileExportServiceInfraestructure
{
    public async Task<byte[]> ExportToExcelAsync<T>(IEnumerable<T> data)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Data");

        // Cargar los datos en la primera fila con nombres de columnas
        worksheet.Cell(1, 1).InsertTable(data);

        // Guardar en un MemoryStream y devolver como byte array
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public async Task<byte[]> ExportToCsvAsync<T>(IEnumerable<T> data)
    {
        using var memoryStream = new MemoryStream();
        using var writer = new StreamWriter(memoryStream, Encoding.UTF8);
        using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));

        await csvWriter.WriteRecordsAsync(data);
        await writer.FlushAsync();

        return memoryStream.ToArray();
    }
}