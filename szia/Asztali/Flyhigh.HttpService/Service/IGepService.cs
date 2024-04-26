using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Flyhigh.HttpService.Service
{
    public interface IGepService : IBaseService<GepAdatok>
    {
        public Task<List<GepAdatok>> SelectAllIncludedAsync();
        public Task<List<GepAdatok>> GetGepekByTipusId(Guid id);
        Task<List<GepAdatok>> GetGepekWithoutTipus();

        public Task<List<GepAdatok>> SearchGep(string keresesSzoveg);
        public Task<List<GepAdatok>> SearchAndFilterGepek(GepAdatokQueryParameters gepekQueryParameters);
    }
}


