using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;
using VetAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Controller
{
    [Route("Tutor")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TutorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
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
        public async Task<ActionResult<IEnumerable<Tutor>>> Get()
        {
            if(_context.Tutors is null) return NotFound();
            return await _context.Tutors.Include(t => t.Contato).Include(t => t.Animais).ToListAsync();
        }

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tutor = await _context.Tutors
                .Include(t => t.Animais) // Inclua a lista de animais associados ao Tutor
                .FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutor == null) return NotFound("Tutor não encontrado.");

            // Remover a referência do Contato associado ao Tutor
            _context.Contatos.RemoveRange(_context.Contatos.Where(t => t.ContatoId == id));


            // Remover a referência do Contato de todos os animais do Tutor
            foreach (var animal in tutor.Animais)
            {
                _context.Animais.RemoveRange(_context.Animais.Where(t => t.AnimalId == animal.AnimalId));
            }

            _context.Tutors.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}