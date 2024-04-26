using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Parameters;
using Flyhigh.Shared.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Flyhigh.HttpService.Service
{

    public class ReptarsService : IReptarsService
    {
        private readonly HttpClient? _httpClient;

        public ReptarsService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("FlyhighApi");
            }
        }

        public async Task<ControllerResponse> RemoveAsync(Guid id)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/Repulotarsasag/{id}");
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAddError("A törlés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        return defaultResponse;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            defaultResponse.ClearAndAddError("Az adatok törlése nem lehetséges!");
            return defaultResponse;
        }

        public async Task<ControllerResponse> InsertAsync(Repulotarsasag repulotarsasag)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Repulotarsasag", repulotarsasag);
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAddError("A mentés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        return defaultResponse;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            defaultResponse.ClearAndAddError("Az adatok mentése nem lehetséges!");
            return defaultResponse;
        }

        public async Task<List<Repulotarsasag>> SelectAllReptars()
        {
            if (_httpClient is not null)
            {
                try {
                    List<RepulotarsasagDto>? resultDto = await _httpClient.GetFromJsonAsync<List<RepulotarsasagDto>>("api/Repulotarsasag");
                    if (resultDto is object)
                    {
                        List<Repulotarsasag> result = resultDto.Select(repDto => repDto.ToRepulo()).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Repulotarsasag>();
        }

        public async Task<ControllerResponse> Update(RepulotarsasagDto repDto)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync("api/Repulotarsasag", repDto);
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                    if (response is not null)
                    {
                        if (response.IsSuccess)
                        {
                            return defaultResponse;
                        }
                        else
                        {
                            Console.WriteLine($"{response.Error}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            defaultResponse.ClearAndAddError("Az adatok frissítése nem lehetséges!");
            return defaultResponse;
        }
        public async Task<List<Repulotarsasag>> SearchAndFilterReptars(RepulotarsasagQueryParameters reptarsQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Reptars/queryparameters", reptarsQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<RepulotarsasagDto>? repulotarsasags = JsonConvert.DeserializeObject<List<RepulotarsasagDto>>(content);
                        if (repulotarsasags is not null)
                        {
                            return repulotarsasags.Select(repulotarsasagDto => repulotarsasagDto.ToRepulo()).ToList();
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
            return new List<Repulotarsasag>();
        }

        public async Task<List<Repulotarsasag>> SearchReptars(string keresesSzoveg)
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<RepulotarsasagDto>? allReptarsDto = await _httpClient.GetFromJsonAsync<List<RepulotarsasagDto>>("api/Reptarsak");
                    if (allReptarsDto is object)
                    {
                        List<Repulotarsasag> talalatok = allReptarsDto
                            .Where(ReptarsDto => ReptarsDto.LastName.Contains(keresesSzoveg, StringComparison.OrdinalIgnoreCase))
                            .Select(ReptarsDto => ReptarsDto.ToRepulo())
                            .ToList();
                        return talalatok;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return new List<Repulotarsasag>();
        }
    }
}
