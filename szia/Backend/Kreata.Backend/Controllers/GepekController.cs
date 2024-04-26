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
    public class GepekController : BaseController<GepAdatok, GepAdatokDto>
    {
        private readonly IGepRepo _gepRepo;

        public GepekController(GepAdatokAssambler assembler, IGepRepo gepRepo) : base(assembler, gepRepo)
        {
            _gepRepo = gepRepo;
        }


        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<GepAdatok>? gepek = new();
            if (_repo != null)
            {
                try
                {
                    gepek = await _gepRepo.GetGepAdatok().ToListAsync();
                    return Ok(gepek.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");

        }


        [HttpGet("bytipusid/{tipusId}")]
        public async Task<IActionResult> SelectGepekByTipusId(Guid tipusId)
        {
            List<GepAdatok>? gepek = new();
            if (_repo != null)
            {
                try
                {
                    gepek = await _gepRepo.SelectGepekByTipusId(tipusId).ToListAsync();
                    return Ok(gepek.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet("withouttipus")]
        public async Task<IActionResult> SelectGepekWithoutTipus()
        {
            List<GepAdatok>? gep = new();
            if (_repo != null)
            {
                try
                {
                    gep = await _gepRepo.SelectGepekWithoutTipus().ToListAsync();
                    return Ok(gep.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        //[HttpPost("queryparameters")]
        //public async Task<IActionResult> GetGepek(GepAdatokQueryParametersDto dto)
        //{
        //    GepAdatokQueryParameters parameters = dto.ToGepAdatoktQueryParameters();
        //    if (!parameters.ValidRange)
        //    {
        //        ControllerResponse response = new ControllerResponse();
        //        response.AppendNewError("A születési év maximuma nagyobb kell legyen a születési év minimumánál!");
        //        return BadRequest(response);
        //    }
        //    else
        //    {
        //        if (_gepRepo is null)
        //        {
        //            ControllerResponse response = new ControllerResponse();
        //            response.AppendNewError("A diákok szűrése születési év alapján nem lehetséges");
        //            return BadRequest(response);
        //        }
        //        else
        //        {
        //            List<GepAdatok> result = await _gepRepo.GetGepAdatok(parameters).ToListAsync();
        //            return Ok(result);
        //        }
        //    }

        //}
    }
}
