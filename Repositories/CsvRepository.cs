using System.Globalization;
using CsvHelper;
using VendorWebApiIntegration.Interfaces;
using VendorWebApiIntegration.Models;

namespace VendorWebApiIntegration.Repositories;

public class CsvRepository : IRepository<CsvRecord>
{
    public IEnumerable<CsvRecord> GetAll(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        csv.Read();
        csv.ReadHeader();
        var headers = csv.HeaderRecord;

        while (csv.Read())
        {
            var record = csv.GetRecord<CsvRecord>();
            record.HeaderRecord = headers;
            record.Row = csv.Parser.Record;
            yield return record;
        }
    }
}