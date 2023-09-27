using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class ContatoController : ControllerBase
{    

    private DocVetDbContext? _dbContext;

    public ContatoController(DocVetDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Contato contato)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Contato is null) return NotFound();
        await _dbContext.AddAsync(contato);
        await _dbContext.SaveChangesAsync();
        return Created("",contato);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Contato>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Contato is null) return NotFound();
        return await _dbContext.Contato.ToListAsync();
    }


    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Contato>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Contato is null) return NotFound();
        var contatoTemp = await _dbContext.Contato.FindAsync(id);
        if(contatoTemp is null) return NotFound();
        return contatoTemp;
    }
    
    //alterar não funcionando
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Contato contato)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Contato is null) return NotFound();
        var contatoTemp = await _dbContext.Contato.FindAsync(contato.Id);
        if(contatoTemp is null) return NotFound();       
        _dbContext.Contato.Update(contato);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Contato is null) return NotFound();
        var contatoTemp = await _dbContext.Contato.FindAsync(id);
        if(contatoTemp is null) return NotFound();
        _dbContext.Remove(contatoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}