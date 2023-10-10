using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class ExameController : ControllerBase
{    
    //contexto da database, onde realiza buscas, incrementações e decrementações
    private DocVetDbContext? _dbContext;
 
    public ExameController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Exame exame)
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.Exame is null) return NotFound();
        //cadastrando no banco de dados
        await _dbContext.AddAsync(exame);
        await _dbContext.SaveChangesAsync();
        return Created("",exame);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Exame>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Exame is null) return NotFound();
        return await _dbContext.Exame.ToListAsync();
    }
 
    
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Exame>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Exame is null) return NotFound();
        var exameTemp = await _dbContext.Exame.FindAsync(id);
        if(exameTemp is null) return NotFound();
        return exameTemp;
    }
    
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Exame exame)
    {
        //tratamento de erro com try/catch
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.Exame is null) return NotFound();      
            _dbContext.Exame.Update(exame);
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
        if(_dbContext.Exame is null) return NotFound();
        var exameTemp = await _dbContext.Exame.FindAsync(id);
        //caso o id inserido não existir, vai retornar notfound
        if(exameTemp is null) return NotFound();
        _dbContext.Remove(exameTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}