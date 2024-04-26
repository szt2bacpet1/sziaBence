using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;

namespace Flyhigh.Shared.Extensions
{
    public static class FelhasznaloExtension
    {
        public static FelhasznaloDto ToFelhasznaloDto(this Felhasznalo felhasznalo)
        {
            return new FelhasznaloDto
            {   
                Id = felhasznalo.Id,
                FirstName = felhasznalo.FirstName,
                LastName = felhasznalo.LastName,
                BirthsDay = felhasznalo.BirthsDay,
                EducationLevelId = felhasznalo.JogosultsagiSzintId,
                EducationLevels = felhasznalo.JogosultsagiSzints

            };
        }

        public static Felhasznalo ToFelhasznalo(this FelhasznaloDto felhasznalodto)
        {
            return new Felhasznalo
            {
                Id = felhasznalodto.Id,
                FirstName = felhasznalodto.FirstName,
                LastName = felhasznalodto.LastName,
                BirthsDay = felhasznalodto.BirthsDay,
                JogosultsagiSzintId = felhasznalodto.EducationLevelId,
                JogosultsagiSzints = felhasznalodto.EducationLevels
            };
        }
    }
}
