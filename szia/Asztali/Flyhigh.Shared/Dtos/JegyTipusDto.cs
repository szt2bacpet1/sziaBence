using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Dtos
{
    public class JegyTipusDto
    {
        public Guid Id { get; set; }
        public string Jegytipus { get; set; } = string.Empty;
        public virtual ICollection<Jegy>? JegyTipusok { get; set; } = new List<Jegy>();


    }
}
