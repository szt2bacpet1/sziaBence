using Flyhigh.Shared.Models;
using Flyhigh.Shared.Assamblers;
using Flyhigh.HttpService.Service;
using Flyhigh.Shared.Dtos;

namespace Flyhigh.HttpService.Services
{
    public class CountryTypeOfService : BaseService<CountryTypeOf, CountryTypeOfDto>, ICountryTypeOfService
    {
        public CountryTypeOfService(IHttpClientFactory? httpClientFactory, CountryTypeOfAssambler assambler) : 
            base(httpClientFactory, assambler)
        {
        }
    }
}
