using VendorWebApiIntegration.Interfaces;
using Newtonsoft.Json;
using VendorWebApiIntegration.Models;

namespace VendorWebApiIntegration.Services;

public class IntegrationService(
    IRepository<CsvRecord> repository,
    IMapper<CsvRecord, LoanRequest> mapper,
    IOutputService output)
{
    private readonly IRepository<CsvRecord> _repository = repository;
    private readonly IMapper<CsvRecord, LoanRequest> _mapper = mapper;
    private readonly IOutputService _output = output;

    public void ProcessDirectory(string inputDir, string outputDir)
    {
        var files = Directory.GetFiles(inputDir, "*.csv");

        foreach (var file in files)
        {
            try
            {
                var records = _repository.GetAll(file);
                var shortFileName = Path.GetFileNameWithoutExtension(file);
                foreach (var record in records)
                {
                    var loanRequest = _mapper.Map(record);
                    var json = JsonConvert.SerializeObject(loanRequest, Formatting.Indented);
                    //var outputFileName = Path.Combine(outputDir, $"{loanRequest.Loan.sLNm}.json");
                    var outputFileName = Path.Combine(outputDir, $"{shortFileName}_{loanRequest.Loan.sLNm}.json");
                    _output.Write(json, outputFileName);
                    Console.WriteLine($"Processed: {outputFileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {file}: {ex.Message}");
            }
        }
    }
}