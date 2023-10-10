using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class HistoricoDoAnimalController : ControllerBase
{    
    //contexto da database, onde realiza buscas, incrementações e decrementações
    private DocVetDbContext? _dbContext;
 
    public HistoricoDoAnimalController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(HistoricoDoAnimal historicoDoAnimal)
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.HistoricoDoAnimal is null) return NotFound();
        //verificando se o Id inserido na(s) classe(s) relacionada(s) ja existe (caso exista, o atributo e definido pela classe ja existente)
        var tutorTemp = await _dbContext.Tutor.FindAsync(historicoDoAnimal.Tutor.Id);
        var animalTemp = await _dbContext.Animal.FindAsync(historicoDoAnimal.Animal.Id);
        if (tutorTemp != null){historicoDoAnimal.Tutor = tutorTemp;}
        if (animalTemp != null) {historicoDoAnimal.Tutor = tutorTemp;}

        //cadastrando no banco de dados
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
        //tratamento de erro com try/catch
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
        //caso o id inserido não existir, vai retornar notfound
        if(historicoDoAnimalTemp is null) return NotFound();
        _dbContext.Remove(historicoDoAnimalTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}