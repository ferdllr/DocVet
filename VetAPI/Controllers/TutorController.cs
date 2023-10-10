using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class TutorController : ControllerBase
{    
    //contexto da database, onde realiza buscas, incrementações e decrementações
    private DocVetDbContext? _dbContext;
 
    public TutorController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Tutor tutor)
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.Tutor is null) return NotFound();
        //verificando se o Id inserido na(s) classe(s) relacionada(s) ja existe (caso exista, o atributo e definido pela classe ja existente)
        var contatoTemp = await _dbContext.Contato.FindAsync(tutor.Contato.Id);
        if (contatoTemp != null){tutor.Contato = contatoTemp;}
        //cadastrando no banco de dados
        await _dbContext.AddAsync(tutor);
        await _dbContext.SaveChangesAsync();
        return Created("",tutor);
    }
 
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Tutor>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Tutor is null) return NotFound();
        return await _dbContext.Tutor.ToListAsync();
    }
 
    //caso a classe tenha id
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Tutor>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Tutor is null) return NotFound();
        var tutorTemp = await _dbContext.Tutor.FindAsync(id);
        if(tutorTemp is null) return NotFound();
        return tutorTemp;
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Tutor tutor)
    {
        //tratamento de erro com try/catch
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.Tutor is null) return NotFound();      
            _dbContext.Tutor.Update(tutor);
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
        if(_dbContext.Tutor is null) return NotFound();
        var tutorTemp = await _dbContext.Tutor.FindAsync(id);
        //caso o id inserido não existir, vai retornar notfound
        if(tutorTemp is null) return NotFound();
        _dbContext.Remove(tutorTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}