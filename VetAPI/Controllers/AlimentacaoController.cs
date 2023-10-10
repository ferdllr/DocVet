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
    public class AlimentacaoController : ControllerBase
    {
        private DocVetDbContext _dbContext;

        public AlimentacaoController(DocVetDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Alimentacao alimentacao)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Alimentacao is null) return NotFound();

            // Verifica se o animal relacionado existe
            var animalTemp = await _dbContext.Animal.FindAsync(alimentacao.AnimalId);
            if (animalTemp is null) return NotFound();

            // Cadastra a alimentação no banco de dados
            await _dbContext.AddAsync(alimentacao);
            await _dbContext.SaveChangesAsync();

            return Created("", alimentacao);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Alimentacao>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Alimentacao is null) return NotFound();

            return await _dbContext.Alimentacao.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Alimentacao>> Buscar(int id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Alimentacao is null) return NotFound();

            var alimentacaoTemp = await _dbContext.Alimentacao.FindAsync(id);
            if (alimentacaoTemp is null) return NotFound();

            return alimentacaoTemp;
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Alimentacao alimentacao)
        {
            try
            {
                if (_dbContext is null) return NotFound();
                if (_dbContext.Alimentacao is null) return NotFound();

                _dbContext.Alimentacao.Update(alimentacao);
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
            if (_dbContext.Alimentacao is null) return NotFound();

            var alimentacaoTemp = await _dbContext.Alimentacao.FindAsync(id);
            if (alimentacaoTemp is null) return NotFound();

            _dbContext.Remove(alimentacaoTemp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
