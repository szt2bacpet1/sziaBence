using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Repos
{
    public interface IJogosultsagiSzintsRepo : IRepositoryBase<JogosultsagiSzints>
    {
        public IQueryable<JogosultsagiSzints> SelectAllIncluded();
    }
}
