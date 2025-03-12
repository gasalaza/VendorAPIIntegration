namespace VendorWebApiIntegration.Services;

using VendorWebApiIntegration.Interfaces;
public class ConsoleOutputService : IOutputService
{
    public void Write(string content, string filename)
    {
        File.WriteAllText(filename, content);
        Console.WriteLine($"File written: {filename}");
    }
}