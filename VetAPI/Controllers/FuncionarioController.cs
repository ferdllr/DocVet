using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetAPI.Data;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{    
    private DocVetDbContext? _dbContext;

    public FuncionarioController(DocVetDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Funcionario funcionario)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Funcionario is null) return NotFound();
        // buscando outra classe referenciada (contato)
        var contatoTemp = await _dbContext.Contato.FindAsync(funcionario.Contato.Id);
        //definindo o contato buscado (caso null, o contato apenas sera null)
        funcionario.Contato = contatoTemp;
        await _dbContext.AddAsync(funcionario);
        await _dbContext.SaveChangesAsync();
        return Created("",funcionario);
    }


    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Funcionario is null) return NotFound();
        return await _dbContext.Funcionario.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Funcionario>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Funcionario is null) return NotFound();
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(id);
        if(funcionarioTemp is null) return NotFound();
        return funcionarioTemp;
    }


    //alterar não funcionando
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Funcionario is null) return NotFound();
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(funcionario.Id);
        if(funcionarioTemp is null) return NotFound();       
        _dbContext.Funcionario.Update(funcionario);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Funcionario is null) return NotFound();
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(id);
        if(funcionarioTemp is null) return NotFound();
        _dbContext.Remove(funcionarioTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}