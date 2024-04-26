using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flyhigh.Shared.Dtos;
using System.Threading.Tasks;
using Flyhigh.Shared.Parameters;

namespace Flyhigh.Shared.Extensions
{
    public static class GepAdatokQueryParametersExtension
    {

        public static GepAdatokQueryParametersDto ToDto(this GepAdatokQueryParameters parameters)
        {
            return new GepAdatokQueryParametersDto
            {
                MaxFoglaltTurista = parameters.MaxFoglaltTurista,
                MinFoglaltTurista = parameters.MinFoglaltTurista,
                Name = parameters.Name
            };
        }

        public static GepAdatokQueryParameters ToGepAdatoktQueryParameters(this GepAdatokQueryParametersDto parameters)
        {
            return new GepAdatokQueryParameters
            {
                MinFoglaltTurista = parameters.MinFoglaltTurista,
                MaxFoglaltTurista = parameters.MaxFoglaltTurista,
                Name = parameters.Name
            };
        }
    }
}
