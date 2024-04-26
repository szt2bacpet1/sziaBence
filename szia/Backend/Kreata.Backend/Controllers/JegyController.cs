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
    public class JegyController : BaseController<Jegy, JegyDto>
    {
        private readonly IJegyRepo _jRepo;

        public JegyController(JegyAssambler assembler, IJegyRepo jRepo) : base(assembler, jRepo)
        {
            _jRepo = jRepo;
        }


        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<Jegy>? j = new();
            if (_repo != null)
            {
                try
                {
                    j = await _jRepo.GetJegyek().ToListAsync();
                    return Ok(j.Select(entity => _assambler.ToDto(entity)));
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
