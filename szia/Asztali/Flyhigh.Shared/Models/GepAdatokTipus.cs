using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class GepAdatokTipus : IDbEntity<GepAdatokTipus>
    {
        public Guid Id { get; set; }
        public string Gepadattipus { get; set; } = string.Empty;
        public virtual ICollection<GepAdatok>? GepekTipus { get; set; } = new List<GepAdatok>();
        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{Gepadattipus}";
        }


    }
}
