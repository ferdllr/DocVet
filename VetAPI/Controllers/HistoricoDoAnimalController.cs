using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class HistoricoDoAnimalController : ControllerBase
{    
 
    private DocVetDbContext? _dbContext;
 
    public HistoricoDoAnimalController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(HistoricoDoAnimal historicoDoAnimal)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.HistoricoDoAnimal is null) return NotFound();
        await _dbContext.AddAsync(historicoDoAnimal);
        await _dbContext.SaveChangesAsync();
        return Created("",historicoDoAnimal);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<HistoricoDoAnimal>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.HistoricoDoAnimal is null) return NotFound();
        return await _dbContext.HistoricoDoAnimal.ToListAsync();
    }
 
    
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<HistoricoDoAnimal>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.HistoricoDoAnimal is null) return NotFound();
        var historicoDoAnimalTemp = await _dbContext.HistoricoDoAnimal.FindAsync(id);
        if(historicoDoAnimalTemp is null) return NotFound();
        return historicoDoAnimalTemp;
    }
    
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(HistoricoDoAnimal historicoDoAnimal)
    {
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.HistoricoDoAnimal is null) return NotFound();      
            _dbContext.HistoricoDoAnimal.Update(historicoDoAnimal);
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
        if(_dbContext.HistoricoDoAnimal is null) return NotFound();
        var historicoDoAnimalTemp = await _dbContext.HistoricoDoAnimal.FindAsync(id);
        if(historicoDoAnimalTemp is null) return NotFound();
        _dbContext.Remove(historicoDoAnimalTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}