using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagement.Server.Data;
using HRManagement.Shared.Models;

namespace HRManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftSkillCandidatiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SoftSkillCandidatiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SoftSkillCandidati
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftSkillCandidato>>> GetSoftSkillsCandidati()
        {
          if (_context.SoftSkillsCandidati == null)
          {
              return NotFound();
          }
            return await _context.SoftSkillsCandidati.ToListAsync();
        }

        // GET: api/SoftSkillCandidati/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoftSkillCandidato>> GetSoftSkillCandidato(int id)
        {
          if (_context.SoftSkillsCandidati == null)
          {
              return NotFound();
          }
            var softSkillCandidato = await _context.SoftSkillsCandidati.FindAsync(id);

            if (softSkillCandidato == null)
            {
                return NotFound();
            }

            return softSkillCandidato;
        }

        // PUT: api/SoftSkillCandidati/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftSkillCandidato(int id, SoftSkillCandidato softSkillCandidato)
        {
            if (id != softSkillCandidato.SofSkillCandidatoId)
            {
                return BadRequest();
            }

            _context.Entry(softSkillCandidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftSkillCandidatoExists(id))
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

        // POST: api/SoftSkillCandidati
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoftSkillCandidato>> PostSoftSkillCandidato(SoftSkillCandidato softSkillCandidato)
        {
          if (_context.SoftSkillsCandidati == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SoftSkillsCandidati'  is null.");
          }
            _context.SoftSkillsCandidati.Add(softSkillCandidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoftSkillCandidato", new { id = softSkillCandidato.SofSkillCandidatoId }, softSkillCandidato);
        }

        // DELETE: api/SoftSkillCandidati/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftSkillCandidato(int id)
        {
            if (_context.SoftSkillsCandidati == null)
            {
                return NotFound();
            }
            var softSkillCandidato = await _context.SoftSkillsCandidati.FindAsync(id);
            if (softSkillCandidato == null)
            {
                return NotFound();
            }

            _context.SoftSkillsCandidati.Remove(softSkillCandidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoftSkillCandidatoExists(int id)
        {
            return (_context.SoftSkillsCandidati?.Any(e => e.SofSkillCandidatoId == id)).GetValueOrDefault();
        }
    }
}
