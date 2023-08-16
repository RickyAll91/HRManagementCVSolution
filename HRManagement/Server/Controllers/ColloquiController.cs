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
    public class ColloquiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ColloquiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Colloqui
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colloquio>>> GetColloquios()
        {
            if (_context.Colloquios == null)
            {
                return NotFound();
            }
            return await _context.Colloquios.ToListAsync();
        }

        // GET: api/Colloqui/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colloquio>> GetColloquio(int id)
        {
            if (_context.Colloquios == null)
            {
                return NotFound();
            }
            var colloquio = await _context.Colloquios.FindAsync(id);

            if (colloquio == null)
            {
                return NotFound();
            }

            return colloquio;
        }

        // PUT: api/Colloqui/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColloquio(int id, Colloquio colloquio)
        {
            if (id != colloquio.ColloquioId)
            {
                return BadRequest();
            }

            _context.Entry(colloquio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColloquioExists(id))
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

        // POST: api/Colloqui
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colloquio>> PostColloquio(Colloquio colloquio)
        {
            if (_context.Colloquios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Colloquios'  is null.");
            }
            _context.Colloquios.Add(colloquio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColloquio", new { id = colloquio.ColloquioId }, colloquio);
        }

        // DELETE: api/Colloqui/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColloquio(int id)
        {
            if (_context.Colloquios == null)
            {
                return NotFound();
            }
            var colloquio = await _context.Colloquios.FindAsync(id);
            if (colloquio == null)
            {
                return NotFound();
            }

            _context.Colloquios.Remove(colloquio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColloquioExists(int id)
        {
            return (_context.Colloquios?.Any(e => e.ColloquioId == id)).GetValueOrDefault();
        }
    }
}
