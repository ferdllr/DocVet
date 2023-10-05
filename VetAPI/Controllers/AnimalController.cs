using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{    
 
    private DocVetDbContext? _dbContext;
 
    public AnimalController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Animal animal)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Animal is null) return NotFound();
        await _dbContext.AddAsync(animal);
        await _dbContext.SaveChangesAsync();
        return Created("",animal);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Animal>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Animal is null) return NotFound();
        return await _dbContext.Animal.ToListAsync();
    }
 
    //caso a classe tenha id
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Animal>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Animal is null) return NotFound();
        var AnimalTemp = await _dbContext.Animal.FindAsync(id);
        if(AnimalTemp is null) return NotFound();
        return AnimalTemp;
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Animal animal)
    {
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.Animal is null) return NotFound();      
            _dbContext.Animal.Update(animal);
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
        if(_dbContext.Animal is null) return NotFound();
        var animalTemp = await _dbContext.Animal.FindAsync(id);
        if(animalTemp is null) return NotFound();
        _dbContext.Remove(animalTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}