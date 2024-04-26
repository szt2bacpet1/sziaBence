using Flyhigh.Shared.Assamblers;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.HttpService.Service
{
    public class JegyService : BaseService<Jegy, JegyDto>, IJegyService
    {
        public JegyService(IHttpClientFactory? httpClientFactory, JegyAssambler jegyAssambler) : base(httpClientFactory, jegyAssambler)
        {
        }
        public async Task<List<Jegy>> SelectAllIncludedAsync()
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<JegyDto>? resultDto = await _httpClient.GetFromJsonAsync<List<JegyDto>>($"api/Jegy/included");
                    if (resultDto is not null)
                    {
                        List<Jegy> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Jegy>();
        }
    }
}
