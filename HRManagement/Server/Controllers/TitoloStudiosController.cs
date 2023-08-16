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
    public class TitoloStudiosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TitoloStudiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TitoloStudios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitoloStudio>>> GetTitoloStudios()
        {
            if (_context.TitoloStudios == null)
            {
                return NotFound();
            }
            return await _context.TitoloStudios.ToListAsync();
        }

        // GET: api/TitoloStudios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitoloStudio>> GetTitoloStudio(int id)
        {
            if (_context.TitoloStudios == null)
            {
                return NotFound();
            }
            var titoloStudio = await _context.TitoloStudios.FindAsync(id);

            if (titoloStudio == null)
            {
                return NotFound();
            }

            return titoloStudio;
        }

        // PUT: api/TitoloStudios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitoloStudio(int id, TitoloStudio titoloStudio)
        {
            if (id != titoloStudio.TitoloStudioId)
            {
                return BadRequest();
            }

            _context.Entry(titoloStudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitoloStudioExists(id))
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

        // POST: api/TitoloStudios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TitoloStudio>> PostTitoloStudio(TitoloStudio titoloStudio)
        {
            if (_context.TitoloStudios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TitoloStudios'  is null.");
            }
            _context.TitoloStudios.Add(titoloStudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitoloStudio", new { id = titoloStudio.TitoloStudioId }, titoloStudio);
        }

        // DELETE: api/TitoloStudios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitoloStudio(int id)
        {
            if (_context.TitoloStudios == null)
            {
                return NotFound();
            }
            var titoloStudio = await _context.TitoloStudios.FindAsync(id);
            if (titoloStudio == null)
            {
                return NotFound();
            }

            _context.TitoloStudios.Remove(titoloStudio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TitoloStudioExists(int id)
        {
            return (_context.TitoloStudios?.Any(e => e.TitoloStudioId == id)).GetValueOrDefault();
        }
    }
}
