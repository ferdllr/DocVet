using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class ProntuarioController : ControllerBase
{    
    //contexto da database, onde realiza buscas, incrementações e decrementações
    private DocVetDbContext? _dbContext;
 
    public ProntuarioController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Prontuario prontuario)
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.Prontuario is null) return NotFound();
        //verificando se o Id inserido na(s) classe(s) relacionada(s) ja existe (caso exista, o atributo e definido pela classe ja existente)
        var animalTemp = await _dbContext.Animal.FindAsync(prontuario.Animal.Id);
        if (animalTemp != null) {prontuario.Animal = animalTemp;}
        //cadastrando no banco de dados
        await _dbContext.AddAsync(prontuario);
        await _dbContext.SaveChangesAsync();
        return Created("",prontuario);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Prontuario>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Prontuario is null) return NotFound();
        return await _dbContext.Prontuario.ToListAsync();
    }
 
    //caso a classe tenha id
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Prontuario>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Prontuario is null) return NotFound();
        var prontuarioTemp = await _dbContext.Prontuario.FindAsync(id);
        if(prontuarioTemp is null) return NotFound();
        return prontuarioTemp;
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Prontuario prontuario)
    {
        //tratamento de erro com try/catch
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.Prontuario is null) return NotFound();      
            _dbContext.Prontuario.Update(prontuario);
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
        if(_dbContext.Prontuario is null) return NotFound();
        var prontuarioTemp = await _dbContext.Prontuario.FindAsync(id);
        //caso o id inserido não existir, vai retornar notfound
        if(prontuarioTemp is null) return NotFound();
        _dbContext.Remove(prontuarioTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}