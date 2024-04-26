using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Models;

namespace Flyhigh.Shared.Assamblers
{
    public class FelhasznaloAssambler : Assambler<Felhasznalo, FelhasznaloDto>
    {
        public override FelhasznaloDto ToDto(Felhasznalo model)
        {
            return model.ToFelhasznaloDto();
        }

        public override Felhasznalo ToModel(FelhasznaloDto dto)
        {
            return dto.ToFelhasznalo();
        }


    }
}
