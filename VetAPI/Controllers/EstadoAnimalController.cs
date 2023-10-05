using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class EstadoAnimalController : ControllerBase
{    
 
    private DocVetDbContext? _dbContext;
 
    public EstadoAnimalController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(EstadoAnimal estadoAnimal)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.EstadoAnimal is null) return NotFound();
        await _dbContext.AddAsync(estadoAnimal);
        await _dbContext.SaveChangesAsync();
        return Created("",estadoAnimal);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<EstadoAnimal>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.EstadoAnimal is null) return NotFound();
        return await _dbContext.EstadoAnimal.ToListAsync();
    }
 
    //caso a classe tenha id
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<EstadoAnimal>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.EstadoAnimal is null) return NotFound();
        var estadoAnimalTemp = await _dbContext.EstadoAnimal.FindAsync(id);
        if(estadoAnimalTemp is null) return NotFound();
        return estadoAnimalTemp;
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(EstadoAnimal estadoAnimal)
    {
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.EstadoAnimal is null) return NotFound();      
            _dbContext.EstadoAnimal.Update(estadoAnimal);
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
        if(_dbContext.EstadoAnimal is null) return NotFound();
        var estadoAnimalTemp = await _dbContext.EstadoAnimal.FindAsync(id);
        if(estadoAnimalTemp is null) return NotFound();
        _dbContext.Remove(estadoAnimalTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}