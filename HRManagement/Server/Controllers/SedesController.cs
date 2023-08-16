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
    public class SedesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SedesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSedes()
        {
            if (_context.Sedes == null)
            {
                return NotFound();
            }
            return await _context.Sedes.ToListAsync();
        }

        // GET: api/Sedes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sede>> GetSede(int id)
        {
            if (_context.Sedes == null)
            {
                return NotFound();
            }
            var sede = await _context.Sedes.FindAsync(id);

            if (sede == null)
            {
                return NotFound();
            }

            return sede;
        }

        // PUT: api/Sedes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSede(int id, Sede sede)
        {
            if (id != sede.SedeId)
            {
                return BadRequest();
            }

            _context.Entry(sede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(id))
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

        // POST: api/Sedes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sede>> PostSede(Sede sede)
        {
            if (_context.Sedes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sedes' is null.");
            }
            _context.Sedes.Add(sede);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SedeExists(sede.SedeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSede", new { id = sede.SedeId }, sede);
        }

        // DELETE: api/Sedes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSede(int id)
        {
            if (_context.Sedes == null)
            {
                return NotFound();
            }
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            _context.Sedes.Remove(sede);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SedeExists(int id)
        {
            return (_context.Sedes?.Any(e => e.SedeId == id)).GetValueOrDefault();
        }
    }
}
