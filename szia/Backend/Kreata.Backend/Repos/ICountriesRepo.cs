using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;
using Microsoft.EntityFrameworkCore;


namespace Flyhigh.Backend.Repos
{
    public interface ICountriesRepo : IRepositoryBase<Countries>
    {
        public IQueryable<Countries> SelectAllIncluded();
    }
}
