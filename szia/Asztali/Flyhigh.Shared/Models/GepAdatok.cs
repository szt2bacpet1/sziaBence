using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class GepAdatok : IDbEntity<GepAdatok>
    {
        public Guid Id { get; set; }
        public Guid? GepAdatokTipusId { get; set; }
        public string Gepneve { get; set; }
        public int Foglaltturista { get; set; }
        public int Foglalt1oszt { get; set; }
        public int Elsoosztulohelyek { get; set; }
        public int Turistaulohelyek { get; set; }
        public string Fajta { get; set; }

        public virtual GepAdatokTipus? GepAdatokTipus { get; set; }

        public bool HasId => Id != Guid.Empty;

        public GepAdatok(string gepneve, int foglaltturista, int foglalt1oszt, int elsoosztulohelyek, int turistaulohelyek, string fajta, Guid gepadatoktipusid)
        {
            Id = Guid.NewGuid();
            Gepneve = gepneve;
            Foglaltturista = foglaltturista;
            Foglalt1oszt = foglalt1oszt;
            Elsoosztulohelyek = elsoosztulohelyek;
            Turistaulohelyek = turistaulohelyek;
            Fajta = fajta;
            GepAdatokTipusId = gepadatoktipusid;

        }

        public GepAdatok()
        {
            Id = Guid.Empty;
            Gepneve = string.Empty;
            Foglaltturista = 0;
            Foglalt1oszt = 0;
            Elsoosztulohelyek = 1;
            Turistaulohelyek = 1;
            Fajta = string.Empty;
            GepAdatokTipusId = Guid.Empty;
        }

        public override string ToString()
        {
            return $"{Id} {Gepneve} {GepAdatokTipus} {Foglaltturista} {Foglalt1oszt} {Elsoosztulohelyek} {Turistaulohelyek} {Fajta}";
        }


    }
}
