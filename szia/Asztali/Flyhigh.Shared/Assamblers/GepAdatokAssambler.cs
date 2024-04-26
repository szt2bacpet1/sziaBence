using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Models;

namespace Flyhigh.Shared.Assamblers
{
    public class GepAdatokAssambler : Assambler<GepAdatok, GepAdatokDto>
    {
        public override GepAdatokDto ToDto(GepAdatok model)
        {
            return model.ToGepAdatokDto();
        }

        public override GepAdatok ToModel(GepAdatokDto dto)
        {
            return dto.ToGepAdatok();
        }


    }
}
