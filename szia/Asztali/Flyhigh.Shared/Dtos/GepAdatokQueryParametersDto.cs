using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Dtos
{
    public class GepAdatokQueryParametersDto
    {
        public uint MinFoglaltTurista { get; set; }
        public uint MaxFoglaltTurista { get; set; }

        public string Name { get; set; } = string.Empty;


    }
}
