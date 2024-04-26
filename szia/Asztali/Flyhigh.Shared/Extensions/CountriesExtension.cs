using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class CountriesExtension
    {
        public static CountriesDto ToCountryDto(this Countries countries)
        {
            return new CountriesDto
            {
                Id = countries.Id,
                CountryName = countries.CountryName,

            };
        }
        public static Countries ToCountry(this CountriesDto countriesdto)
        {
            return new Countries
            {
                Id = countriesdto.Id,
                CountryName = countriesdto.CountryName,


            };
        }


    }
}
