using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TutorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post([FromBody] Tutor tutor)
        {
            if (_context.Tutors is null) return NotFound();
            Contato? contatoTemp = await _context.Contatos.FindAsync(tutor.Contato.ContatoId);
            if(contatoTemp != null) tutor.Contato = contatoTemp;
            _context.Tutors.Add(tutor);
            await _context.SaveChangesAsync();

            return Ok(tutor);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Tutor>>> Get()
        {
            if(_context.Tutors is null) return NotFound();
            return await _context.Tutors.Include(t => t.Contato).Include(t => t.Animais).ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tutor = await _context.Tutors
            .Include(t => t.Contato)
            .Include(t => t.Animais)
            .FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tutor tutor)
        {
            if (id != tutor.TutorId)
            {
                return BadRequest();
            }

            Contato? contatoTemp = await _context.Contatos.FindAsync(tutor.Contato.ContatoId);
            if(contatoTemp != null) tutor.Contato = contatoTemp;


            _context.Entry(tutor).State = EntityState.Modified;
            _context.Entry(tutor.Contato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tutors.Any(e => e.TutorId == id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tutor = await _context.Tutors
                .Include(t => t.Animais)
                .Include(t => t.Contato)
                .FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null) return NotFound("Tutor não encontrado.");

            tutor.Animais = null;
            tutor.Contato = null;
            _context.Tutors.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}