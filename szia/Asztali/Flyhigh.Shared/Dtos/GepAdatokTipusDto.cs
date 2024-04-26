using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Dtos
{
    public class GepAdatokTipusDto
    {
        public Guid Id { get; set; }
        public string Gepadattipus { get; set; } = string.Empty;
        public ICollection<GepAdatok>? Gepek { get; set; } = new List<GepAdatok>();

    }
}
