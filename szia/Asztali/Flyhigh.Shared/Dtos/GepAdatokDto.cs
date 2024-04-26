using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flyhigh.Shared.Enums;
using Flyhigh.Shared.Models;

namespace Flyhigh.Shared.Dtos
{
    public class GepAdatokDto
    {
        public Guid Id { get; set; }
        public Guid? GepAdatokTipusId { get; set; } = Guid.Empty;
        public string Gepneve { get; set; } = string.Empty;
        public int Foglaltturista { get; set; } = 0;
        public int Foglalt1oszt { get; set; } = 0;
        public int Elsoosztulohelyek { get; set; } = 0;
        public int Turistaulohelyek { get; set; } = 0;
        public string Fajta { get; set; } = string.Empty;
        public virtual GepAdatokTipus? GepAdatokTipus { get; set; }


    }
}
