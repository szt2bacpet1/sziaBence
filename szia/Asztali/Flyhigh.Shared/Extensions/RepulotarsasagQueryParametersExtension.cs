using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class RepulotarsasagQueryParametersExtension
    {
        public static RepulotarsasagQueryParametersDto ToDto(this RepulotarsasagQueryParameters parameters)
        {
            return new RepulotarsasagQueryParametersDto
            {
                Name = parameters.Name
            };
        }

        public static RepulotarsasagQueryParameters ToRepulotarsasagQueryParameters(this RepulotarsasagQueryParametersDto parameters)
        {
            return new RepulotarsasagQueryParameters
            {
                Name = parameters.Name
            };
        }
    }
}
