using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("Vacina")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VacinaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacina>>> Get()
        {
            if (_context.Vacinas is null) return NotFound();
            return await _context.Vacinas.Include(v => v.Animal).ToListAsync();
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Post([FromBody] Vacina vacina)
        {
            if (_context.Vacinas is null) return NotFound();
            var animalTemp = await _context.Animais.FindAsync(vacina.Animal.AnimalId);
            if (animalTemp != null) vacina.Animal = animalTemp;
            _context.Vacinas.Add(vacina);
            await _context.SaveChangesAsync();
            return Ok(vacina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vacina vacina)
        {
            if (_context.Vacinas is null) return NotFound();
            if (id != vacina.VacinaId) return BadRequest();
            var animalTemp = await _context.Animais.FindAsync(vacina.Animal.AnimalId);
            if (animalTemp != null) vacina.Animal = animalTemp;
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

        [HttpDelete("{id}")]
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
