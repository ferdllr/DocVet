using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("EstadoDoAnimal")]
    [ApiController]
    public class EstadoDoAnimalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadoDoAnimalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDoAnimal>>> Get()
        {
            if (_context.EstadoDoAnimals is null) return NotFound();
            return await _context.EstadoDoAnimals.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var estadoDoAnimal = await _context.EstadoDoAnimals
                .FirstOrDefaultAsync(e => e.EstadoDoAnimalId == id);

            if (estadoDoAnimal == null)
            {
                return NotFound();
            }

            return Ok(estadoDoAnimal);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstadoDoAnimal estadoDoAnimal)
        {
            if (_context.EstadoDoAnimals is null) return NotFound();
            _context.EstadoDoAnimals.Add(estadoDoAnimal);
            await _context.SaveChangesAsync();
            return Ok(estadoDoAnimal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstadoDoAnimal estadoDoAnimal)
        {
            if (_context.EstadoDoAnimals is null) return NotFound();
            if (id != estadoDoAnimal.EstadoDoAnimalId) return BadRequest();
            _context.Entry(estadoDoAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.EstadoDoAnimals.Any(e => e.EstadoDoAnimalId == id))
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estadoDoAnimal = await _context.EstadoDoAnimals.FindAsync(id);
            if (estadoDoAnimal == null)
            {
                return NotFound();
            }

            _context.EstadoDoAnimals.Remove(estadoDoAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}