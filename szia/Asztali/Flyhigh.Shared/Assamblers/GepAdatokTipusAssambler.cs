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
    public class GepAdatokTipusAssambler : Assambler<GepAdatokTipus, GepAdatokTipusDto>
    {
        public override GepAdatokTipusDto ToDto(GepAdatokTipus domainEntity)
        {
            return domainEntity.ToDto();
        }

        public override GepAdatokTipus ToModel(GepAdatokTipusDto dto)
        {
            return dto.ToModel();
        }


    }
}
