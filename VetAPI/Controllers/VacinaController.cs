using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VacinaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Vacina>>> Get()
        {
            if (_context.Vacinas is null) return NotFound();
            return await _context.Vacinas.Include(v => v.Animal).ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vacina = await _context.Vacinas
                .Include(v => v.Animal)
                .FirstOrDefaultAsync(v => v.VacinaId == id);

            if (vacina == null)
            {
                return NotFound();
            }

            return Ok(vacina);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post([FromBody] Vacina vacina)
        {
            if (_context.Vacinas is null) return NotFound();
            _context.Vacinas.Add(vacina);
            await _context.SaveChangesAsync();
            return Ok(vacina);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vacina vacina)
        {
            if (_context.Vacinas is null) return NotFound();
            if (id != vacina.VacinaId) return BadRequest();
            
            _context.Entry(vacina).State = EntityState.Modified;
            _context.Entry(vacina.Animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Vacinas.Any(e => e.VacinaId == id))
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
            var vacina = await _context.Vacinas.Include(v => v.Animal).FirstOrDefaultAsync(v => v.VacinaId == id);
            if (vacina == null)
            {
                return NotFound();
            }
            vacina.Animal = null;
            _context.Vacinas.Remove(vacina);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
