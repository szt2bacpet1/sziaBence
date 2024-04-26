using Flyhigh.Backend.Repos;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Flyhigh.Shared.Assamblers;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GepAdatokTipusController : BaseController<GepAdatokTipus, GepAdatokTipusDto>
    {
        private readonly IGepAdatokTipusRepo _tipusRepo;
        public GepAdatokTipusController(GepAdatokTipusAssambler assembler, IGepAdatokTipusRepo repo) : base(assembler, repo)
        {
            _tipusRepo = repo;
        }

        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<GepAdatokTipus>? tipusok = new();
            if (_repo != null)
            {
                try
                {
                    tipusok = await _tipusRepo.SelectAllIncluded().ToListAsync();
                    return Ok(tipusok.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);

                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
    }


}
