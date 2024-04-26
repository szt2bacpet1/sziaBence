using Flyhigh.Backend.Repos;
using Flyhigh.Shared.Assamblers;
using Flyhigh.Shared.Dtos;
using Flyhigh.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JegyTipusController : BaseController<JegyTipus, JegyTipusDto>
    {
        private readonly IJegyTipusRepo _tipusRepo;
        public JegyTipusController(JegyTipusAssambler assembler, IJegyTipusRepo repo) : base(assembler, repo)
        {
            _tipusRepo = repo;
        }

        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<JegyTipus>? tipusok = new();
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
