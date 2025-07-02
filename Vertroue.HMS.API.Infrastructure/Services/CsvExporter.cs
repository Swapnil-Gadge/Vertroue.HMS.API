using Vertroue.HMS.API.Application.Contracts.Infrastructure;

using CsvHelper;

using System.Globalization;

namespace Vertroue.HMS.API.Infrastructure.Services
{
    public class CsvExporter : ICsvExporter
    {
        //public byte[] ExportProductsToCsv(List<ProductExportDto> productExportDtos)
        //{
        //    using var memoryStream = new MemoryStream();
        //    using (var streamWriter = new StreamWriter(memoryStream))
        //    {
        //        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        //        csvWriter.WriteRecords(productExportDtos);
        //    }

        //    return memoryStream.ToArray();
        //}
    }
}
