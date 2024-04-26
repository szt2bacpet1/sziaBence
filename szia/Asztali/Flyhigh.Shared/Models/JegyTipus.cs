using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class JegyTipus : IDbEntity<JegyTipus>
    {
        public Guid Id { get; set; }
        public string Jegytipus { get; set; } = string.Empty;
        public virtual ICollection<Jegy>? JegyTipusok { get; set; } = new List<Jegy>();
        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{JegyTipusok}";
        }


    }
}
