using HRManagement.Server.Data;
using HRManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CandidatoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Candidatoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos()
        {
            if (_context.Candidatos == null)
            {
                return NotFound();
            }
            return await _context.Candidatos.ToListAsync();
        }

        // GET: api/Candidatoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            if (_context.Candidatos == null)
            {
                return NotFound();
            }
            var candidato = await _context.Candidatos.FindAsync(id);

            if (candidato == null)
            {
                return NotFound();
            }

            return candidato;
        }

        // PUT: api/Candidatoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (id != candidato.CandidatoId)
            {
                return BadRequest();
            }

            _context.Entry(candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Candidatoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Candidato>> PostCandidato(Candidato candidato)
        {
            if (_context.Candidatos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Candidatos'  is null.");
            }
            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidato", new { id = candidato.CandidatoId }, candidato);
        }

        // DELETE: api/Candidatoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            if (_context.Candidatos == null)
            {
                return NotFound();
            }
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatoExists(int id)
        {
            return (_context.Candidatos?.Any(e => e.CandidatoId == id)).GetValueOrDefault();
        }
    }
}
