using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Extensions;


namespace Flyhigh.Shared.Assamblers
{
    public class CountriesAssambler : Assambler<Countries, CountriesDto>
    {
        public override CountriesDto ToDto(Countries model)
        {
            return model.ToCountryDto();
        }
        public override Countries ToModel(CountriesDto dto)
        {
            return dto.ToCountry();
        }
    }
}
