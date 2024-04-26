using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Flyhigh.Shared.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flyhigh.HttpService.Service
{
    public interface IJogosultsagokService
    {
        public Task<List<Felhasznalo>> SelectAllFelhasznalo();
        public Task<ControllerResponse> Update(FelhasznaloDto felhasznaloDto);
        public Task<ControllerResponse> RemoveAsync(Guid id);
        public Task<ControllerResponse> InsertAsync(Felhasznalo felhasznalo);
        public Task<List<Felhasznalo>> SearchAndFilterFelhasznalo(FelhasznaloQueryParameters felhasznaloQueryParameters);

    }
}
