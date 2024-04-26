using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class RepulotarsasagExtension
    {
        public static RepulotarsasagDto ToRepuloDto(this Repulotarsasag repulotarsasag)
        {
            return new RepulotarsasagDto
            {
                Id = repulotarsasag.Id,
                CountryId = repulotarsasag.CountryId,
                LastName = repulotarsasag.LastName,
                BirthsDay = repulotarsasag.BirthsDay,
                Country = repulotarsasag.Country,
                Countries = repulotarsasag.Countries,
            };
        }
        public static Repulotarsasag ToRepulo(this RepulotarsasagDto repulotarsasagdto)
        {
            return new Repulotarsasag
            {
                Id = repulotarsasagdto.Id,
                CountryId = repulotarsasagdto.CountryId,
                LastName = repulotarsasagdto.LastName,
                BirthsDay = repulotarsasagdto.BirthsDay,
                Country = repulotarsasagdto.Country,
                Countries = repulotarsasagdto.Countries,


            };
        }


    }
}
