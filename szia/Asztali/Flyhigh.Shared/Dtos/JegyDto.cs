using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Dtos
{
    public class JegyDto
    {
        public Guid Id { get; set; }
        public Guid? JegyId { get; set; } = Guid.Empty;
        public string Megrendelo_nev { get; set; } = string.Empty;
        public string Indulas_hely { get; set; } = string.Empty;
        public string Erkezes_hely { get; set; } = string.Empty;
        public string Indulasido { get; set; } = string.Empty;
        public string Erkezesido { get; set; } = string.Empty;
        public string Osztaly { get; set; } = string.Empty;
        public int Utazok { get; set; } = 0;
        public int Ar { get; set; } = 0;
        public string SorSzek { get; set; } = string.Empty;

    }
}
