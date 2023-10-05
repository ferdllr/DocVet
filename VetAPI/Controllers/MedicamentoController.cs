using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MedicamentoController : ControllerBase
{    

    private DocVetDbContext? _dbContext;

    public MedicamentoController(DocVetDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Medicamento medicamento)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Medicamento is null) return NotFound();
        await _dbContext.AddAsync(medicamento);
        await _dbContext.SaveChangesAsync();
        return Created("",medicamento);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Medicamento>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Medicamento is null) return NotFound();
        return await _dbContext.Medicamento.ToListAsync();
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Medicamento medicamento)
    {
        try{
            if(_dbContext is null) return NotFound();
            if(_dbContext.Medicamento is null) return NotFound();      
            _dbContext.Medicamento.Update(medicamento);
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
        if(_dbContext.Medicamento is null) return NotFound();
        var medicamentoTemp = await _dbContext.Medicamento.FindAsync(id);
        if(medicamentoTemp is null) return NotFound();
        _dbContext.Remove(medicamentoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}