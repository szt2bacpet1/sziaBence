using Flyhigh.Shared.Enums;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Dtos
{
    public class FelhasznaloDto
    {
        public Guid Id { get; set; }
        public Guid EducationLevelId { get; set; } = Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public virtual JogosultsagiSzints? EducationLevels { get; set; }


    }
}
