using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProcedimentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProcedimentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Procedimento>>> Get()
        {
            if (_context.Procedimentos is null) return NotFound();
            return await _context.Procedimentos.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var procedimento = await _context.Procedimentos
                .FirstOrDefaultAsync(p => p.ProcedimentoId == id);

            if (procedimento == null)
            {
                return NotFound();
            }

            return Ok(procedimento);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post([FromBody] Procedimento procedimento)
        {
            if (_context.Procedimentos is null) return NotFound();
            _context.Procedimentos.Add(procedimento);
            await _context.SaveChangesAsync();
            return Ok(procedimento);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Procedimento procedimento)
        {
            if (_context.Procedimentos is null) return NotFound();
            if (id != procedimento.ProcedimentoId) return BadRequest();
            _context.Entry(procedimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Procedimentos.Any(e => e.ProcedimentoId == id))
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
            var procedimento = await _context.Procedimentos.FindAsync(id);
            if (procedimento == null)
            {
                return NotFound();
            }

            _context.Procedimentos.Remove(procedimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}