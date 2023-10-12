using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("Funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Funcionario funcionario)
    {
        if(_context.Funcionarios is null) return NotFound();
        Contato? contatoTemp = await _context.Contatos.FindAsync(funcionario.Contato.ContatoId);
        if(contatoTemp != null) funcionario.Contato = contatoTemp;
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return Ok(funcionario);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
    {
        if(_context.Funcionarios is null) return NotFound();
        return await _context.Funcionarios.Include(f => f.Contato).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var funcionario = await _context.Funcionarios
            .Include(f => f.Contato)
            .FirstOrDefaultAsync(f => f.FuncionarioId == id);

        if (funcionario == null)
        {
            return NotFound();
        }

        return Ok(funcionario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Funcionario funcionario)
    {
        if (id != funcionario.FuncionarioId)
        {
            return BadRequest();
        }

        Contato? contatoTemp = await _context.Contatos.FindAsync(funcionario.Contato.ContatoId);
        if(contatoTemp != null) funcionario.Contato = contatoTemp;
        _context.Entry(funcionario).State = EntityState.Modified;
        _context.Entry(funcionario.Contato).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Funcionarios.Any(e => e.FuncionarioId == id))
            {
                return NotFound();
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario == null)
        {
            return NotFound();
        }

        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
}