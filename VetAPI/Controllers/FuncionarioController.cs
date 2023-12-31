using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Post([FromBody] Funcionario funcionario)
    {
        if(_context.Funcionarios is null) return NotFound();

        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return Ok(funcionario);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
    {
        if(_context.Funcionarios is null) return NotFound();
        return await _context.Funcionarios.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var funcionario = await _context.Funcionarios
            .FirstOrDefaultAsync(f => f.FuncionarioId == id);

        if (funcionario == null)
        {
            return NotFound();
        }

        return Ok(funcionario);
    }

    [HttpPut]
    [Route("alterar/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Funcionario funcionario)
    {
        if (id != funcionario.FuncionarioId)
        {
            return BadRequest();
        }
        
        _context.Entry(funcionario).State = EntityState.Modified;        

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

    [HttpDelete]
    [Route("excluir/{id}")]
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