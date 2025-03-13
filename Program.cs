using VendorWebApiIntegration.Interfaces;
using VendorWebApiIntegration.Repositories;
using VendorWebApiIntegration.Services;
using VendorWebApiIntegration.Mappers;
using VendorWebApiIntegration.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var inputDir = "./input";
            var outputDir = "./output";

            IRepository<CsvRecord> repository = new CsvRepository();
            IMapper<CsvRecord, LoanRequest> mapper = new LoanRequestMapper();
            IOutputService outputService = new ConsoleOutputService();

            var integrationService = new IntegrationService(repository, mapper, outputService);

            integrationService.ProcessDirectory(inputDir, outputDir);

            Console.WriteLine("All files have been processed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex.Message}");
        }
    }
}