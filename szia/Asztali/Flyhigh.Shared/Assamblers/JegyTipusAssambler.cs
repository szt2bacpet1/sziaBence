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
    public class JegyTipusAssambler : Assambler<JegyTipus, JegyTipusDto>
    {
        public override JegyTipusDto ToDto(JegyTipus domainEntity)
        {
            return domainEntity.ToDto();
        }

        public override JegyTipus ToModel(JegyTipusDto dto)
        {
            return dto.ToModel();
        }

    }
}
