using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Extensions
{
    public static class JogosultsagiSzintExtension
    {
        public static JogosultsagiSzintsDto ToEducationLevelsDto(this JogosultsagiSzints educationLevels)
        {
            return new JogosultsagiSzintsDto
            {
                Id = educationLevels.Id,
                EducationLevel = educationLevels.JogosultsagiSzint,
                EducationLevels = educationLevels.AllJogosultsagiSzints
            };
        }

        public static JogosultsagiSzints ToEducationLevels(this JogosultsagiSzintsDto educationLevelsDto)
        {
            return new JogosultsagiSzints
            {
                Id = educationLevelsDto.Id,
                JogosultsagiSzint = educationLevelsDto.EducationLevel,
                AllJogosultsagiSzints = educationLevelsDto.EducationLevels
            };
        }
    }
}
