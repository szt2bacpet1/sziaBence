using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class CountryTypeOf : IDbEntity<CountryTypeOf>
    {
        public Guid Id { get; set; }

        public bool HasId => Id != Guid.Empty;
        public virtual  ICollection<Repulotarsasag>? Repulotarsasags { get; set; } = new List<Repulotarsasag>();

        public string CountryName { get; set; } = string.Empty;
    }
}
