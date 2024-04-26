using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flyhigh.Shared.Models;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Dtos
{
    public class CountriesDto
    {
        public Guid Id { get; set; }

        public string CountryName { get; set; } = string.Empty;
        public virtual ICollection<Repulotarsasag>? Repulotarsasags { get; set; } = new List<Repulotarsasag>();
    }
}
