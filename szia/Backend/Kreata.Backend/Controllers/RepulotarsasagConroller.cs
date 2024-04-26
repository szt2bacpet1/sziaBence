using Flyhigh.Backend.Repos;
using Microsoft.AspNetCore.Mvc;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Extensions;
using Flyhigh.Shared.Responses;
using Flyhigh.Shared.Assamblers;
using Microsoft.EntityFrameworkCore;
using Flyhigh.Shared.Parameters;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Flyhigh.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepulotarsasagController : BaseController<Repulotarsasag, RepulotarsasagDto>
    {
        private readonly IRepulotarsRepo _reptarsRepo;

        
        public RepulotarsasagController(RepuloAssambler assambler, IRepulotarsRepo reptarsRepo) : base(assambler, reptarsRepo)
        {
            _reptarsRepo = reptarsRepo;
        }

        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<Repulotarsasag>? reptars = new();
            if (_repo != null)
            {
                try
                {
                    reptars = await _reptarsRepo.SelectAllIncluded().ToListAsync();
                    return Ok(reptars.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }


            [HttpPost("queryparameters")]
        public async Task<IActionResult> GetReptars(RepulotarsasagQueryParametersDto dto)
        {
            RepulotarsasagQueryParameters parameters = dto.ToRepulotarsasagQueryParameters();
            if (parameters.Name is null)
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError("A születési év maximuma nagyobb kell legyen a születési év minimumánál!");
                return BadRequest(response);
            }
            else
            {
                if (_reptarsRepo is null)
                {
                    ControllerResponse response = new ControllerResponse();
                    response.AppendNewError("A diákok szűrése születési év alapján nem lehetséges");
                    return BadRequest(response);
                }
                else
                {
                    List<Repulotarsasag> result = await _reptarsRepo.GetReptarsAdatok(parameters).ToListAsync();
                    return Ok(result);
                }
            }

        }

    }
    }

