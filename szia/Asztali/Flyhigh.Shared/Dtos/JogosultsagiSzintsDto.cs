using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Dtos
{
    public class JogosultsagiSzintsDto
    {
        public Guid Id { get; set; }
        public string EducationLevel { get; set; } = string.Empty;
        public virtual ICollection<Felhasznalo> EducationLevels { get; set; } = new List<Felhasznalo>();
    }
}
