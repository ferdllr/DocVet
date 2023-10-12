using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("Medicamento")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicamento>>> Get()
        {
            if (_context.Medicamentos is null) return NotFound();
            return await _context.Medicamentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var medicamento = await _context.Medicamentos
                .FirstOrDefaultAsync(m => m.MedicamentoId == id);

            if (medicamento == null)
            {
                return NotFound();
            }

            return Ok(medicamento);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medicamento medicamento)
        {
            if (_context.Medicamentos is null) return NotFound();
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();
            return Ok(medicamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Medicamento medicamento)
        {
            if (_context.Medicamentos is null) return NotFound();
            if (id != medicamento.MedicamentoId) return BadRequest();
            _context.Entry(medicamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Medicamentos.Any(e => e.MedicamentoId == id))
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            _context.Medicamentos.Remove(medicamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}