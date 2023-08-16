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
    public class MansionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MansionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mansiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mansione>>> GetMansiones()
        {
            if (_context.Mansiones == null)
            {
                return NotFound();
            }
            return await _context.Mansiones.ToListAsync();
        }

        // GET: api/Mansiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mansione>> GetMansione(int id)
        {
            if (_context.Mansiones == null)
            {
                return NotFound();
            }
            var mansione = await _context.Mansiones.FindAsync(id);

            if (mansione == null)
            {
                return NotFound();
            }

            return mansione;
        }

        // PUT: api/Mansiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMansione(int id, Mansione mansione)
        {
            if (id != mansione.MansioneId)
            {
                return BadRequest();
            }

            _context.Entry(mansione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MansioneExists(id))
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

        // POST: api/Mansiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mansione>> PostMansione(Mansione mansione)
        {
            if (_context.Mansiones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mansiones'  is null.");
            }
            _context.Mansiones.Add(mansione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMansione", new { id = mansione.MansioneId }, mansione);
        }

        // DELETE: api/Mansiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMansione(int id)
        {
            if (_context.Mansiones == null)
            {
                return NotFound();
            }
            var mansione = await _context.Mansiones.FindAsync(id);
            if (mansione == null)
            {
                return NotFound();
            }

            _context.Mansiones.Remove(mansione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MansioneExists(int id)
        {
            return (_context.Mansiones?.Any(e => e.MansioneId == id)).GetValueOrDefault();
        }
    }
}
