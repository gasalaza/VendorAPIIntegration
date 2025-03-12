namespace VendorWebApiIntegration.Interfaces;

public interface IOutputService
{
    void Write(string content, string filename);
}