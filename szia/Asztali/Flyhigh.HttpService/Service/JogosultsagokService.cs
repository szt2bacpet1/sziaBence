using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Flyhigh.Shared.Parameters;
using System.Diagnostics;

namespace Flyhigh.HttpService.Service
{
    public class JogosultsagokService : IJogosultsagokService
    {
        private readonly HttpClient? _httpClient;

        public JogosultsagokService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("FlyhighApi");
            }
        }

        public JogosultsagokService() 
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Felhasznalo>> SelectAllFelhasznalo()
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<FelhasznaloDto>? resultDto = await _httpClient.GetFromJsonAsync<List<FelhasznaloDto>>("api/Felhasznalo");
                    if (resultDto is not null)
                    {
                        List<Felhasznalo> result = resultDto.Select(felhasznalo => felhasznalo.ToFelhasznalo()).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
                return new List<Felhasznalo>();
        }
        public async Task<ControllerResponse> Update(FelhasznaloDto felhasznaloDto)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync("api/Felhasznalo", felhasznaloDto);
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
            defaultResponse.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return defaultResponse;

        }
        public async Task<ControllerResponse> DeleteAsync(Guid id)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/Felhasznalo/{id}");
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
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
            defaultResponse.ClearAndAddError("Az adatok törlés nem lehetséges!");
            return defaultResponse;
        }
        public async Task<ControllerResponse> InsertAsync(Felhasznalo felhasznalo)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Felhasznalo", felhasznalo);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
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
        public async Task<List<Felhasznalo>> SearchAndFilterReptars(FelhasznaloQueryParameters felhasznaloQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Felhasznalo/queryparameters", felhasznaloQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<FelhasznaloDto>? felhasznalos = JsonConvert.DeserializeObject<List<FelhasznaloDto>>(content);
                        if (felhasznalos is not null)
                        {
                            return felhasznalos.Select(felhasznaloDto => felhasznaloDto.ToFelhasznalo()).ToList();
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
            return new List<Felhasznalo>();
        }

        public async Task<List<Felhasznalo>> SearchFelhasznalo(string keresesSzoveg)
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<FelhasznaloDto>? allFelhasznaloDto = await _httpClient.GetFromJsonAsync<List<FelhasznaloDto>>("api/Felhasznalo");
                    if (allFelhasznaloDto is object)
                    {
                        List<Felhasznalo> talalatok = allFelhasznaloDto
                            .Where(FelhasznaloDto => FelhasznaloDto.LastName.Contains(keresesSzoveg, StringComparison.OrdinalIgnoreCase))
                            .Select(FelhasznaloDto => FelhasznaloDto.ToFelhasznalo())
                            .ToList();
                        return talalatok;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return new List<Felhasznalo>();
        }

        public async Task<ControllerResponse> RemoveAsync(Guid id)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/Felhasznalo/{id}");
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
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
            defaultResponse.ClearAndAddError("Az adatok törlés nem lehetséges!");
            return defaultResponse;
        }

        public async Task<List<Felhasznalo>> SearchAndFilterFelhasznalo(FelhasznaloQueryParameters felhasznaloQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Felhasznalo/queryparameters", felhasznaloQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<FelhasznaloDto>? felhasznalo = JsonConvert.DeserializeObject<List<FelhasznaloDto>>(content);
                        if (felhasznalo is not null)
                        {
                            return felhasznalo.Select(felhasznaloDto => felhasznaloDto.ToFelhasznalo()).ToList();
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
            return new List<Felhasznalo>();
        }
    }
}
