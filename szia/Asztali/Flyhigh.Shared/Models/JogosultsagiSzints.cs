using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class JogosultsagiSzints : IDbEntity<JogosultsagiSzints>
    {
        public Guid Id { get; set; }
        public string JogosultsagiSzint { get; set; } = string.Empty;
        public virtual ICollection<Felhasznalo>? AllJogosultsagiSzints { get; set; } = new List<Felhasznalo>();

        public bool HasId => Id != Guid.Empty;

        //public EducationLevels(Guid id, string lastName, DateTime birthsDay, string educationlevel)
        //{
        //    Id = id;
        //    LastName = lastName;
        //    BirthsDay = birthsDay;
        //    EducationLevel = educationlevel;
        //}

        //public EducationLevels(string lastName, DateTime birthsDay, string educationlevel)
        //{
        //    Id = Guid.NewGuid();
        //    LastName = lastName;
        //    BirthsDay = birthsDay;
        //    EducationLevel = educationlevel;
        //}

        //public EducationLevels()
        //{
        //    Id = Guid.NewGuid();
        //    LastName = string.Empty;
        //    BirthsDay = new DateTime();
        //    EducationLevel = string.Empty;
        //}

        public override string ToString()
        {
            return $"{JogosultsagiSzint}";
        }
    }
}