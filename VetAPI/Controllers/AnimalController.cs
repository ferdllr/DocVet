using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{    
    //contexto da database, onde realiza buscas, incrementações e decrementações
    private DocVetDbContext? _dbContext;
 
    public AnimalController(DocVetDbContext context)
    {
        _dbContext = context;
    }
    
    
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Animal animal)
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.Animal is null) return NotFound();
        //verificando se o Id inserido na(s) classe(s) relacionada(s) ja existe (caso exista, o atributo e definido pela classe ja existente)
        var tutorTemp = await _dbContext.Tutor.FindAsync(animal.Tutor.Id);
        if (tutorTemp != null){animal.Tutor = tutorTemp;}
        //cadastrando no banco de dados
        await _dbContext.AddAsync(animal);
        await _dbContext.SaveChangesAsync();
        return Created("",animal);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Animal>>> Listar()
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.Animal is null) return NotFound();
        //retornando a lista
        return await _dbContext.Animal.ToListAsync();
    }
 
    //caso a classe tenha id
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Animal>> Buscar(int id)
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
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
        //tratamento de erro com try/catch
        try{
            //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
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
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.Animal is null) return NotFound();
        var animalTemp = await _dbContext.Animal.FindAsync(id);
        //caso o id inserido não existir, vai retornar notfound
        if(animalTemp is null) return NotFound();
        // remove do banco de dados
        _dbContext.Remove(animalTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}