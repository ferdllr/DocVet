using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace VetAPI.Controller
{
    [Route("Animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> Get()
        {
            if (_context.Animais is null) return NotFound();
            return await _context.Animais.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _context.Animais
                .FirstOrDefaultAsync(a => a.AnimalId == id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Animal animal)
        {
            if (_context.Animais is null) return NotFound();
            _context.Animais.Add(animal);
            await _context.SaveChangesAsync();
            return Ok(animal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Animal animal)
        {
            if (_context.Animais is null) return NotFound();
            if (id != animal.AnimalId) return BadRequest();
            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Animais.Any(e => e.AnimalId == id))
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _context.Animais.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animais.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}