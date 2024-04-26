using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flyhigh.Shared.Enums;
using Flyhigh.Shared.Models;

namespace Flyhigh.Shared.Dtos
{
    public class RepulotarsasagDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }

        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Country { get; set; }
        public virtual Countries? Countries{ get; set; }

        public RepulotarsasagDto(Guid id, string lastName, DateTime birthsDay, string country)
        {
            Id = id;
            LastName = lastName;
            BirthsDay = birthsDay;
            Country = country;
        }

        public RepulotarsasagDto()
        {
            Id = Guid.NewGuid();
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Country = string.Empty;
        }


    }
}
