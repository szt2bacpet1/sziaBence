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
    public class JogosultsagiSzintController : BaseController<JogosultsagiSzints, JogosultsagiSzintsDto>
    {
        private readonly IJogosultsagiSzintsRepo _jogosultsagiSzintRepo;


        public JogosultsagiSzintController(JogosultsagiSzintAssambler assembler, IJogosultsagiSzintsRepo repo) : base(assembler, repo)
        {
            _jogosultsagiSzintRepo = repo;
        }

        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<JogosultsagiSzints>? jogosultsagiSzints = new();
            if (_repo != null)
            {
                try
                {
                    jogosultsagiSzints = await _jogosultsagiSzintRepo.SelectAllIncluded().ToListAsync();
                    return Ok(jogosultsagiSzints.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
    }
}