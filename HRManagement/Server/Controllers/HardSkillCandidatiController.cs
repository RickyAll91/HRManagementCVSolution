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
    public class HardSkillCandidatiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HardSkillCandidatiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HardSkillCandidati
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardSkillCandidato>>> GetHardSkillsCandidati()
        {
          if (_context.HardSkillsCandidati == null)
          {
              return NotFound();
          }
            return await _context.HardSkillsCandidati.ToListAsync();
        }

        // GET: api/HardSkillCandidati/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HardSkillCandidato>> GetHardSkillCandidato(int id)
        {
          if (_context.HardSkillsCandidati == null)
          {
              return NotFound();
          }
            var hardSkillCandidato = await _context.HardSkillsCandidati.FindAsync(id);

            if (hardSkillCandidato == null)
            {
                return NotFound();
            }

            return hardSkillCandidato;
        }

        // PUT: api/HardSkillCandidati/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHardSkillCandidato(int id, HardSkillCandidato hardSkillCandidato)
        {
            if (id != hardSkillCandidato.HardSkillCandidatoId)
            {
                return BadRequest();
            }

            _context.Entry(hardSkillCandidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HardSkillCandidatoExists(id))
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

        // POST: api/HardSkillCandidati
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HardSkillCandidato>> PostHardSkillCandidato(HardSkillCandidato hardSkillCandidato)
        {
          if (_context.HardSkillsCandidati == null)
          {
              return Problem("Entity set 'ApplicationDbContext.HardSkillsCandidati'  is null.");
          }
            _context.HardSkillsCandidati.Add(hardSkillCandidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHardSkillCandidato", new { id = hardSkillCandidato.HardSkillCandidatoId }, hardSkillCandidato);
        }

        // DELETE: api/HardSkillCandidati/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHardSkillCandidato(int id)
        {
            if (_context.HardSkillsCandidati == null)
            {
                return NotFound();
            }
            var hardSkillCandidato = await _context.HardSkillsCandidati.FindAsync(id);
            if (hardSkillCandidato == null)
            {
                return NotFound();
            }

            _context.HardSkillsCandidati.Remove(hardSkillCandidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HardSkillCandidatoExists(int id)
        {
            return (_context.HardSkillsCandidati?.Any(e => e.HardSkillCandidatoId == id)).GetValueOrDefault();
        }
    }
}
