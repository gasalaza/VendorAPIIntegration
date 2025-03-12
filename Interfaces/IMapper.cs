using VendorWebApiIntegration.Models;

namespace VendorWebApiIntegration.Interfaces;

public interface IMapper<TInput, TOutput>
{
    TOutput Map(TInput input);
}