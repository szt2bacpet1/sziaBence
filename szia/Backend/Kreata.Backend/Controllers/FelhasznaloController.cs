using Flyhigh.Backend.Repos;
using Microsoft.AspNetCore.Mvc;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using Flyhigh.Shared.Parameters;
using Microsoft.AspNetCore.Mvc.Controllers;
using Flyhigh.Shared.Assamblers;


namespace Flyhigh.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FelhasznaloController : BaseController<Felhasznalo, FelhasznaloDto>
    {
        private readonly IFelhasznaloRepo _felhasznaloRepo;


        public FelhasznaloController(FelhasznaloAssambler assembler, IFelhasznaloRepo felhasznaloRepo) : base(assembler, felhasznaloRepo)
        {
            _felhasznaloRepo = felhasznaloRepo;

        }

        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<Felhasznalo>? jogosultsagiSzints = new();
            if (_repo != null)
            {
                try
                {
                    jogosultsagiSzints = await _felhasznaloRepo.SelectAllIncluded().ToListAsync();
                    return Ok(jogosultsagiSzints.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }


        [HttpPost("queryparameters")]
        public async Task<IActionResult> GetFelhasznalo(FelhasznaloQueryParametersDto dto)
        {
            FelhasznaloQueryParameters parameters = dto.ToFelhasznaloQueryParameters();

                if (_felhasznaloRepo is null)
                {
                    ControllerResponse response = new ControllerResponse();
                    response.AppendNewError("A diákok szűrése születési év alapján nem lehetséges");
                    return BadRequest(response);
                }
                else
                {
                    List<Felhasznalo> result = await _felhasznaloRepo.GetFelhasznalo(parameters).ToListAsync();
                    return Ok(result);
                }

        }
    }
}