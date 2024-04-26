using System;
using System.Collections.Generic;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net;
using Flyhigh.Shared.Parameters;
using System.Diagnostics;
using Flyhigh.HttpService.Service;
using Flyhigh.Shared.Assamblers;

namespace Flyhigh.HttpService.Service
{
    public class GepService : BaseService<GepAdatok, GepAdatokDto>, IGepService
    {
        public GepService(IHttpClientFactory? httpClientFactory, GepAdatokAssambler gepAssambler) : base(httpClientFactory, gepAssambler)
        {
        }

        public async Task<List<GepAdatok>> SearchGep(string keresesSzoveg)
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<GepAdatokDto>? allGepekDto = await _httpClient.GetFromJsonAsync<List<GepAdatokDto>>("api/Gepek");
                    if (allGepekDto is object)
                    {
                        List<GepAdatok> talalatok = allGepekDto
                            .Where(gepekDto => gepekDto.Gepneve.Contains(keresesSzoveg, StringComparison.OrdinalIgnoreCase))
                            .Select(gepekDto => gepekDto.ToGepAdatok())
                            .ToList();
                        return talalatok;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return new List<GepAdatok>();
        }



        public async Task<List<GepAdatok>> SearchAndFilterGepek(GepAdatokQueryParameters gepekQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Gepek/queryparameters", gepekQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<GepAdatokDto>? gepek = JsonConvert.DeserializeObject<List<GepAdatokDto>>(content);
                        if (gepek is not null)
                        {
                            return gepek.Select(gepekdto => gepekdto.ToGepAdatok()).ToList();
                        }
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return new List<GepAdatok>();
        }


        public async Task<List<GepAdatok>> SelectAllIncludedAsync()
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<GepAdatokDto>? resultDto = await _httpClient.GetFromJsonAsync<List<GepAdatokDto>>($"api/Gepek/included");
                    if (resultDto is not null)
                    {
                        List<GepAdatok> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<GepAdatok>();
        }

        public async Task<List<GepAdatok>> GetGepekByTipusId(Guid tipusId)
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<GepAdatokDto>? resultDto = await _httpClient.GetFromJsonAsync<List<GepAdatokDto>>($"api/Gepek/bytipusid/{tipusId}");
                    if (resultDto is not null)
                    {
                        List<GepAdatok> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<GepAdatok>();
        }

        public async Task<List<GepAdatok>> GetGepekWithoutTipus()
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<GepAdatokDto>? resultDto = await _httpClient.GetFromJsonAsync<List<GepAdatokDto>>($"api/Gepek/withouttipus");
                    if (resultDto is not null)
                    {
                        List<GepAdatok> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<GepAdatok>();
        }
    }
}
