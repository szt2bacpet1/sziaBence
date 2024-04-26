using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Assamblers
{
    public class JogosultsagiSzintAssambler : Assambler<JogosultsagiSzints, JogosultsagiSzintsDto>
    {
        public override JogosultsagiSzintsDto ToDto(JogosultsagiSzints model)
        {
            return model.ToEducationLevelsDto();
        }

        public override JogosultsagiSzints ToModel(JogosultsagiSzintsDto dto)
        {
            return dto.ToEducationLevels();
        }


    }
}