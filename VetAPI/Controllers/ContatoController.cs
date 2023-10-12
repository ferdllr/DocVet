using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("Contato")]
    [ApiController]
    public class ContatoController: ControllerBase
    {
        private AppDbContext? _context;

        public ContatoController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> Get()
        {
            if(_context.Contatos is null) return NotFound();
            return await _context.Contatos.ToListAsync();
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var contato = await _context.Contatos
            .FirstOrDefaultAsync(f => f.ContatoId == id);

        if (contato == null)
        {
            return NotFound();
        }

        return Ok(contato);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Contato contato)
    {
        if(_context.Contatos is null) return NotFound();
        _context.Contatos.Add(contato);
        await _context.SaveChangesAsync();
        return Ok(contato);
    }
    [HttpPut]
    public async Task<IActionResult> Put(int id, [FromBody] Contato contato)
    {
        if(_context.Contatos is null) return NotFound();
        if(id != contato.ContatoId)return BadRequest();
        _context.Entry(contato).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Contatos.Any(e => e.ContatoId == id))
            {
                return NotFound();
            }

        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var contato = await _context.Contatos.FindAsync(id);
        if (contato == null)
        {
            return NotFound();
        }
        _context.Tutors.RemoveRange(_context.Tutors.Where(t => t.Contato.ContatoId == id));
        _context.Funcionarios.RemoveRange(_context.Funcionarios.Where(f => f.Contato.ContatoId == id));

        _context.Contatos.Remove(contato);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    }

    

}