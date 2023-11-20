using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExameController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("cadastrar")]
        public async Task<ActionResult<IEnumerable<Exame>>> Get()
        {
            if (_context.Exames is null) return NotFound();
            return await _context.Exames.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var exame = await _context.Exames
                .FirstOrDefaultAsync(e => e.ExameId == id);

            if (exame == null)
            {
                return NotFound();
            }

            return Ok(exame);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post([FromBody] Exame exame)
        {
            if (_context.Exames is null) return NotFound();
            _context.Exames.Add(exame);
            await _context.SaveChangesAsync();
            return Ok(exame);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Exame exame)
        {
            if (_context.Exames is null) return NotFound();
            if (id != exame.ExameId) return BadRequest();
            _context.Entry(exame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Exames.Any(e => e.ExameId == id))
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
            var exame = await _context.Exames.FindAsync(id);
            if (exame == null)
            {
                return NotFound();
            }

            _context.Exames.Remove(exame);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}