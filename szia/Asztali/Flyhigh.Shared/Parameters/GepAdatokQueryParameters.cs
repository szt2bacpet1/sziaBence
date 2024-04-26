using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Parameters
{
    public class GepAdatokQueryParameters
    {
        public uint MinFoglaltTurista { get; set; }
        public uint MaxFoglaltTurista { get; set; }


        public bool ValidRange => MaxFoglaltTurista > MinFoglaltTurista;

        public string Name { get; set; } = string.Empty;


    }
}
