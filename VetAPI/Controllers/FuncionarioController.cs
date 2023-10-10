using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetAPI.Data;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{    
    //contexto da database, onde realiza buscas, incrementações e decrementações
    private DocVetDbContext? _dbContext;

    public FuncionarioController(DocVetDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Funcionario funcionario)
    {
        //teste para verificar se a conexão com o banco de dados esta funcionando e se ele existe (caso não, retorna NotFound)
        if(_dbContext is null) return NotFound();
        if(_dbContext.Funcionario is null) return NotFound();
        //verificando se o Id inserido na(s) classe(s) relacionada(s) ja existe (caso exista, o atributo e definido pela classe ja existente)
        var contatoTemp = await _dbContext.Contato.FindAsync(funcionario.Contato.Id);
        if (contatoTemp != null){funcionario.Contato = contatoTemp;}
        //cadastrando no banco de dados
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


    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        //tratamento de erro com try/catch
        try{
        if(_dbContext is null) return NotFound();
        if(_dbContext.Funcionario is null) return NotFound();      
        _dbContext.Funcionario.Update(funcionario);
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
        if(_dbContext.Funcionario is null) return NotFound();
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(id);
        //caso o id inserido não existir, vai retornar notfound
        if(funcionarioTemp is null) return NotFound();
        _dbContext.Remove(funcionarioTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}