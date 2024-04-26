using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flyhigh.HttpService.Service
{
    public interface IReptarsService
    {

        public Task<List<Repulotarsasag>> SearchReptars(string keresesSzoveg);
        public Task<List<Repulotarsasag>> SelectAllReptars();
        public Task<ControllerResponse> Update(RepulotarsasagDto repDto);
        public Task<ControllerResponse> RemoveAsync(Guid id);
        public Task<ControllerResponse> InsertAsync(Repulotarsasag repulotarsasag);

        public Task<List<Repulotarsasag>> SearchAndFilterReptars(RepulotarsasagQueryParameters reptarsQueryParameters);
    }
}
