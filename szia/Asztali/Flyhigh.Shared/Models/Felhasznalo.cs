using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flyhigh.Shared.Enums;

namespace Flyhigh.Shared.Models
{

    public class Felhasznalo : IDbEntity<Felhasznalo>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string JogosultsagiSzint { get; set; }
        public Guid JogosultsagiSzintId { get; set; }
        public virtual JogosultsagiSzints? JogosultsagiSzints { get; set; }


    public bool HasId => Id != Guid.Empty;



        public Felhasznalo(string firstName, string lastName, DateTime birthsDay, Guid educationlevelid, string educationlevel)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            JogosultsagiSzint = educationlevel;
            JogosultsagiSzintId = educationlevelid;
        }

        public Felhasznalo()
        {
            Id=Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            JogosultsagiSzint = string.Empty;
            JogosultsagiSzintId = Guid.Empty;
        }

        public override string ToString()
        {
            return $"{Id} {LastName} {FirstName} - ({String.Format("{0:yyyy.MM.dd.}", BirthsDay)}) ({JogosultsagiSzint})";
        }
    }
}
