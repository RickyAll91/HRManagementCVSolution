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
    [Route("api/dipendenti")]
    [ApiController]
    public class DipendentesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DipendentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dipendenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dipendente>>> GetDipendentes()
        {
            if (_context.Dipendenti == null)
            {
                return NotFound();
            }
            return await _context.Dipendenti.ToListAsync();
        }

        // GET: api/Dipendenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dipendente>> GetDipendente(int id)
        {
            if (_context.Dipendenti == null)
            {
                return NotFound();
            }
            var dipendente = await _context.Dipendenti.FindAsync(id);

            if (dipendente == null)
            {
                return NotFound();
            }

            return dipendente;
        }

        // PUT: api/Dipendenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDipendente(int id, Dipendente dipendente)
        {
            if (id != dipendente.DipendenteId)
            {
                return BadRequest();
            }

            _context.Entry(dipendente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DipendenteExists(id))
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

        // POST: api/Dipendenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dipendente>> PostDipendente(Dipendente dipendente)
        {
            if (_context.Dipendenti == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dipendenti'  is null.");
            }
            _context.Dipendenti.Add(dipendente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDipendente", new { id = dipendente.DipendenteId }, dipendente);
        }

        // DELETE: api/Dipendenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDipendente(int id)
        {
            if (_context.Dipendenti == null)
            {
                return NotFound();
            }
            var dipendente = await _context.Dipendenti.FindAsync(id);
            if (dipendente == null)
            {
                return NotFound();
            }

            _context.Dipendenti.Remove(dipendente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DipendenteExists(int id)
        {
            return (_context.Dipendenti?.Any(e => e.DipendenteId == id)).GetValueOrDefault();
        }
    }
}
