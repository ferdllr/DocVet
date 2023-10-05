using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace VetAPI.Controllers;
 
 
[ApiController]
[Route("[controller]")]
public class TutorController : ControllerBase
{    
 
    private DocVetDbContext? _dbContext;
 
    public TutorController(DocVetDbContext context)
    {
        _dbContext = context;
    }
 
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Tutor tutor)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Tutor is null) return NotFound();
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
        if(tutorTemp is null) return NotFound();
        _dbContext.Remove(tutorTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}