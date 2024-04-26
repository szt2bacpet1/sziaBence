using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class Jegy : IDbEntity<Jegy>
    {
        public Guid Id { get; set; }
        public Guid? JegyId { get; set; }
        public string Megrendelo_nev { get; set; }
        public string Indulas_hely { get; set; }
        public string Erkezes_hely { get; set; }
        public string Indulasido { get; set; }
        public string Erkezesido { get; set; }
        public string Osztaly { get; set; }
        public int Utazok { get; set; }
        public int Ar { get; set; }
        public string SorSzek { get; set; }

        public virtual JegyTipus? JegyTipus { get; set; }


        public bool HasId => Id != Guid.Empty;

        public Jegy(string megrendelo, string indulas, string erkezes, string indulasido, string erkezesido, string osztaly, int utazok, int ar, string sorszek, Guid jegyid)
        {
            Id = Guid.NewGuid();
            Megrendelo_nev = megrendelo;
            Indulas_hely = indulas;
            Erkezes_hely = erkezes;
            Indulasido = indulasido;
            Erkezesido = erkezesido;
            Osztaly = osztaly;
            Utazok = utazok;
            Ar = ar;
            SorSzek = sorszek;
            JegyId = jegyid;

        }

        public Jegy()
        {
            Id = Guid.NewGuid();
            Megrendelo_nev = string.Empty;
            Indulas_hely = string.Empty;
            Erkezes_hely = string.Empty;
            Indulasido = string.Empty;
            Erkezesido = string.Empty;
            Osztaly = string.Empty;
            Utazok = 0;
            Ar = 0;
            SorSzek = string.Empty;
            JegyId = Guid.Empty;

        }

        public override string ToString()
        {
            return $"{Id} {Megrendelo_nev} {Indulas_hely} {Erkezes_hely} {Indulasido} {Erkezesido} {Osztaly} {Utazok} {Ar} {SorSzek}";
        }


    }
}
