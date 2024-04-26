using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Extensions;


namespace Flyhigh.Shared.Assamblers
{
    public class RepuloAssambler : Assambler<Repulotarsasag, RepulotarsasagDto>
    {
        public override RepulotarsasagDto ToDto(Repulotarsasag model)
        {
            return model.ToRepuloDto();
        }

        public override Repulotarsasag ToModel(RepulotarsasagDto dto)
        {
            return dto.ToRepulo();
        }
    }
}
