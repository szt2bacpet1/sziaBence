﻿using Flyhigh.Shared.Assamblers;
using Flyhigh.Backend.Repos;
using Flyhigh.Shared.Models;
using Flyhigh.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Controllers
{
    public abstract class BaseController<Tmodel, TDto> : ControllerBase
       where Tmodel : class, IDbEntity<Tmodel>, new()
       where TDto : class, new()
    {
        protected readonly Assambler<Tmodel, TDto> _assambler;
        protected readonly IRepositoryBase<Tmodel> _repo;

        public BaseController(Assambler<Tmodel, TDto> assembler, IRepositoryBase<Tmodel> repo)
        {
            _assambler = assembler;
            _repo = repo;
        }
        [HttpGet]
        public virtual async Task<IActionResult> SelectAllAsync()
        {
            List<Tmodel>? entities = new();

            if (_repo != null)
            {
                entities = await _repo.FindAll().ToListAsync();
                return Ok(entities.Select(entity => _assambler.ToDto(entity)));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Tmodel? entity = new();
            if (_repo is not null)
            {
                entity = await _repo.FindByCondition(entity => entity.Id == id).FirstOrDefaultAsync();
                if (entity != null)
                    return Ok(_assambler.ToDto(entity));
                else
                    return Ok(_assambler.ToDto(new Tmodel()));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateAsync(TDto entity)
        {
            ControllerResponse response = new();
            if (_repo is not null)
            {
                response = await _repo.UpdateAsync(_assambler.ToModel(entity));
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("Az adatok módosítása nem sikerült!");
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ControllerResponse response = new();
            if (_repo is not null)
            {
                response = await _repo.DeleteAsync(id);
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("Az  adatok törlése nem sikerült!");
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }

        [HttpPost()]
        public async Task<IActionResult> InsertAsync(TDto entity)
        {
            ControllerResponse response = new();
            if (_repo is not null)
            {
                response = await _repo.CreateAsync(_assambler.ToModel(entity));
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }
    }
}