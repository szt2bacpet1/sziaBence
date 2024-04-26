using Flyhigh.Shared.Assamblers;
using Flyhigh.Backend.Repos;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Flyhigh.Backend.Controllers
{
   
    
        [ApiController]
        [Route("api/[controller]")]
        public class CountriesController : BaseController<Countries, CountriesDto>
        {
            private readonly ICountriesRepo _countriesRepo;


            public CountriesController(CountriesAssambler assembler, ICountriesRepo repo) : base(assembler, repo)
            {
            _countriesRepo = repo;
            }

            [HttpGet("included")]
            public async Task<IActionResult> SelectAllIncludedAsync()
            {
                List<Countries>? countries = new();
                if (_repo != null)
                {
                    try
                    {
                    countries = await _countriesRepo.SelectAllIncluded().ToListAsync();
                        return Ok(countries.Select(entity => _assambler.ToDto(entity)));
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return BadRequest("Az adatok elérhetetlenek!");
            }
        }
}
