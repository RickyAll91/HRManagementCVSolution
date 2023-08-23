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
    public class ProvinciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvinciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Provincie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetProvincia()
        {
            if (_context.Provincie == null)
            {
                return NotFound();
            }
            return await _context.Provincie.ToListAsync();
        }

        // GET: api/Provincie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> GetProvincium(int id)
        {
            if (_context.Provincie == null)
            {
                return NotFound();
            }
            var provincium = await _context.Provincie.FindAsync(id);

            if (provincium == null)
            {
                return NotFound();
            }

            return provincium;
        }

        // PUT: api/Provincie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincium(int id, Provincia provincium)
        {
            if (id != provincium.ProvinciaId)
            {
                return BadRequest();
            }

            _context.Entry(provincium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciumExists(id))
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

        // POST: api/Provincie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Provincia>> PostProvincium(Provincia provincium)
        {
            if (_context.Provincie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Provincie'  is null.");
            }
            _context.Provincie.Add(provincium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvincium", new { id = provincium.ProvinciaId }, provincium);
        }

        // DELETE: api/Provincie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvincium(int id)
        {
            if (_context.Provincie == null)
            {
                return NotFound();
            }
            var provincium = await _context.Provincie.FindAsync(id);
            if (provincium == null)
            {
                return NotFound();
            }

            _context.Provincie.Remove(provincium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvinciumExists(int id)
        {
            return (_context.Provincie?.Any(e => e.ProvinciaId == id)).GetValueOrDefault();
        }
    }
}
