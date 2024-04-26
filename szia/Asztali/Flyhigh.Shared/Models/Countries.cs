using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class Countries : IDbEntity<Countries>
    {
        public Guid Id { get; set; }
        public string CountryName { get; set; } = string.Empty;

        public virtual ICollection<Repulotarsasag>? Repulotarsasags { get; set; } = new List<Repulotarsasag>();
        public bool HasId => Id != Guid.Empty;
        public List<string> AllAirportCountry { get; } = new List<string>
        {
            "Ausztria",
            "Belgium",
            "Bulgária",
            "Ciprus",
            "Csehország",
            "Dánia",
            "Észtország",
            "Finnország",
            "Franciaország",
            "Görögország",
            "Horvátország",
            "Írország",
            "Lengyelország",
            "Lettország",
            "Litvánia",
            "Luxemburg",
            "Magyarország",
            "Málta",
            "Németország",
            "Hollandia",
            "Portugália",
            "Románia",
            "Spanyolország",
            "Svédország",
            "Szlovákia",
            "Szlovénia"
        };
    }
}
