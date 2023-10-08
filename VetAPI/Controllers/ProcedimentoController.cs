using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class ProcedimentoController : ControllerBase
{    
 
    private DocVetDbContext? _dbContext;
 
    public ProcedimentoController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Procedimento procedimento)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Procedimento is null) return NotFound();
        await _dbContext.AddAsync(procedimento);
        await _dbContext.SaveChangesAsync();
        return Created("",procedimento);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Procedimento>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Procedimento is null) return NotFound();
        return await _dbContext.Procedimento.ToListAsync();
    }
 
    
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Procedimento>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Procedimento is null) return NotFound();
        var procedimentoTemp = await _dbContext.Procedimento.FindAsync(id);
        if(procedimentoTemp is null) return NotFound();
        return procedimentoTemp;
    }
    
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Procedimento procedimento)
    {
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.Procedimento is null) return NotFound();      
            _dbContext.Procedimento.Update(procedimento);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch{
            return BadRequest();
        }
    }
 
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Procedimento is null) return NotFound();
        var procedimentoTemp = await _dbContext.Procedimento.FindAsync(id);
        if(procedimentoTemp is null) return NotFound();
        _dbContext.Remove(procedimentoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}