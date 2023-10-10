using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetAPI.Data;
using VetAPI.Models;

namespace VetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacinaController : ControllerBase
    {
        private DocVetDbContext _dbContext;

        public VacinaController(DocVetDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Vacina vacina)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Vacina is null) return NotFound();

            // Verifica se o animal relacionado existe
            var animalTemp = await _dbContext.Animal.FindAsync(vacina.AnimalId);
            if (animalTemp is null) return NotFound();

            // Cadastra a vacina no banco de dados
            await _dbContext.AddAsync(vacina);
            await _dbContext.SaveChangesAsync();

            return Created("", vacina);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Vacina>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Vacina is null) return NotFound();

            return await _dbContext.Vacina.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Vacina>> Buscar(int id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Vacina is null) return NotFound();

            var vacinaTemp = await _dbContext.Vacina.FindAsync(id);
            if (vacinaTemp is null) return NotFound();

            return vacinaTemp;
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Vacina vacina)
        {
            try
            {
                if (_dbContext is null) return NotFound();
                if (_dbContext.Vacina is null) return NotFound();

                _dbContext.Vacina.Update(vacina);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Vacina is null) return NotFound();

            var vacinaTemp = await _dbContext.Vacina.FindAsync(id);
            if (vacinaTemp is null) return NotFound();

            _dbContext.Remove(vacinaTemp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
