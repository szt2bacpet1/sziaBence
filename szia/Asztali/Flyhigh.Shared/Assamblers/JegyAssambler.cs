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
    public class JegyAssambler : Assambler<Jegy, JegyDto>
    {
        public override JegyDto ToDto(Jegy model)
        {
            return model.ToJegyDto();
        }

        public override Jegy ToModel(JegyDto dto)
        {
            return dto.ToJegy();
        }


    }
}
