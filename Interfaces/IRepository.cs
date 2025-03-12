namespace VendorWebApiIntegration.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll(string filePath);
}