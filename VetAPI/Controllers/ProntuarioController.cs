using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProntuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProntuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Prontuario>>> Get()
        {
            if (_context.Prontuarios is null) return NotFound();
            return await _context.Prontuarios.Include(p => p.Animal).ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prontuario = await _context.Prontuarios.Include(p => p.Animal).FirstOrDefaultAsync(p => p.ProntuarioId == id);

            if (prontuario == null)
            {
                return NotFound();
            }

            return Ok(prontuario);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post([FromBody] Prontuario prontuario)
        {
            if (_context.Prontuarios is null) return NotFound();
            var animalTemp = await _context.Animais.FindAsync(prontuario.Animal.AnimalId);
            if (animalTemp != null) prontuario.Animal = animalTemp;
            _context.Prontuarios.Add(prontuario);
            await _context.SaveChangesAsync();
            return Ok(prontuario);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Prontuario prontuario)
        {
            if (_context.Prontuarios is null) return NotFound();
            if (id != prontuario.ProntuarioId) return BadRequest();
            var animalTemp = await _context.Animais.FindAsync(prontuario.Animal.AnimalId);
            if (animalTemp != null) prontuario.Animal = animalTemp;
            _context.Entry(prontuario).State = EntityState.Modified;
            _context.Entry(prontuario.Animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Prontuarios.Any(e => e.ProntuarioId == id))
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
            var prontuario = await _context.Prontuarios
            .Include(p => p.Medicamentos)
            .Include(p => p.EstadosAnimais)
            .Include(p => p.Animal)
            .FirstOrDefaultAsync(p => p.ProntuarioId == id);
            if (prontuario == null)
            {
                return NotFound();
            }
            prontuario.Animal = null;
            prontuario.Medicamentos = null;
            prontuario.EstadosAnimais = null;
            _context.Prontuarios.Remove(prontuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}