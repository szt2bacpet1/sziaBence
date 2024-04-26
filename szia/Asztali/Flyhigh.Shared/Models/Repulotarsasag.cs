using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public class Repulotarsasag : IDbEntity<Repulotarsasag>
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public virtual Countries? Countries { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Country { get; set; }
        public string CountryName { get; set; }
        public bool HasId => Id != Guid.Empty;

        public Repulotarsasag(Guid id, string lastName, DateTime birthsDay, string country, string countryName)
        {
            Id = id;
            LastName = lastName;
            BirthsDay = birthsDay;
            Country = country;
            CountryName = countryName;
        }

        public Repulotarsasag(string lastName, DateTime birthsDay, string country, string countryName)
        {
            Id = Guid.NewGuid();
            LastName = lastName;
            BirthsDay = birthsDay;
            Country = country;
            CountryName = countryName;
        }

        public Repulotarsasag()
        {
            Id = Guid.NewGuid();
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Country = string.Empty;
            CountryName = string.Empty;
        }

        public override string ToString()
        {
            return $" {Id} {LastName} ({String.Format("{0:yyyy.MM.dd.}", BirthsDay)}) - {Country}";
        }
    }
}
