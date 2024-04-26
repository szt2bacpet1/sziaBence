using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flyhigh.Shared.Dtos;
using System.Threading.Tasks;
using Flyhigh.Shared.Parameters;

namespace Flyhigh.Shared.Extensions
{
    public static class FelhasznaloQueryParametersExtension
    {

        public static FelhasznaloQueryParametersDto ToDto(this FelhasznaloQueryParameters parameters)
        {
            return new FelhasznaloQueryParametersDto
            {
                Name = parameters.Name,
            };
        }

        public static FelhasznaloQueryParameters ToFelhasznaloQueryParameters(this FelhasznaloQueryParametersDto parameters)
        {
            return new FelhasznaloQueryParameters
            {
                Name = parameters.Name,
            };
        }
    }
}