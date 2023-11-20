using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AlimentacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlimentacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Alimentacao>>> Get()
        {
            if (_context.Alimentacaos is null) return NotFound();
            return await _context.Alimentacaos.Include(a => a.Animal).ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var alimentacao = await _context.Alimentacaos
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(a => a.AlimentacaoId == id);

            if (alimentacao == null)
            {
                return NotFound();
            }

            return Ok(alimentacao);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post([FromBody] Alimentacao alimentacao)
        {
            if (_context.Alimentacaos is null) return NotFound();
            var animalTemp = await _context.Animais.FindAsync(alimentacao.Animal.AnimalId);
            if (animalTemp != null) alimentacao.Animal = animalTemp;
            _context.Alimentacaos.Add(alimentacao);
            await _context.SaveChangesAsync();
            return Ok(alimentacao);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alimentacao alimentacao)
        {
            if (_context.Alimentacaos is null) return NotFound();
            if (id != alimentacao.AlimentacaoId) return BadRequest();
            var animalTemp = await _context.Animais.FindAsync(alimentacao.Animal.AnimalId);
            if (animalTemp != null) alimentacao.Animal = animalTemp;
            _context.Entry(alimentacao).State = EntityState.Modified;
            _context.Entry(alimentacao.Animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Alimentacaos.Any(e => e.AlimentacaoId == id))
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
            var alimentacao = await _context.Alimentacaos.Include(a => a.Animal).FirstOrDefaultAsync(a => a.AlimentacaoId == id);
            if (alimentacao == null)
            {
                return NotFound();
            }
            alimentacao.Animal = null;
            _context.Alimentacaos.Remove(alimentacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}