using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class HistoricoDoAnimalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistoricoDoAnimalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<HistoricoDoAnimal>>> Get()
        {
            if (_context.HistoricoDoAnimals is null) return NotFound();
            return await _context.HistoricoDoAnimals.Include(h => h.Prontuarios).ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var historicoDoAnimal = await _context.HistoricoDoAnimals
                .Include(h => h.Prontuarios)
                .FirstOrDefaultAsync(h => h.HistoricoDoAnimalId == id);

            if (historicoDoAnimal == null)
            {
                return NotFound();
            }

            return Ok(historicoDoAnimal);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post([FromBody] HistoricoDoAnimal historicoDoAnimal)
        {
            if (_context.HistoricoDoAnimals is null) return NotFound();
            _context.HistoricoDoAnimals.Add(historicoDoAnimal);
            await _context.SaveChangesAsync();
            return Ok(historicoDoAnimal);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HistoricoDoAnimal historicoDoAnimal)
        {
            if (_context.HistoricoDoAnimals is null) return NotFound();
            if (id != historicoDoAnimal.HistoricoDoAnimalId) return BadRequest();
            _context.Entry(historicoDoAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.HistoricoDoAnimals.Any(e => e.HistoricoDoAnimalId == id))
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var historicoDoAnimal = await _context.HistoricoDoAnimals.Include(h => h.Prontuarios).FirstOrDefaultAsync(h => h.HistoricoDoAnimalId == id);
            if (historicoDoAnimal == null)
            {
                return NotFound();
            }
            historicoDoAnimal.Prontuarios = null;
            _context.HistoricoDoAnimals.Remove(historicoDoAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
