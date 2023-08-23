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
    public class ComunesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComunesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comuni
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comune>>> GetComunes()
        {
            if (_context.Comuni == null)
            {
                return NotFound();
            }
            return await _context.Comuni.ToListAsync();
        }

        // GET: api/Comuni/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comune>> GetComune(int id)
        {
            if (_context.Comuni == null)
            {
                return NotFound();
            }
            var comune = await _context.Comuni.FindAsync(id);

            if (comune == null)
            {
                return NotFound();
            }

            return comune;
        }

        // PUT: api/Comuni/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComune(int id, Comune comune)
        {
            if (id != comune.ComuneId)
            {
                return BadRequest();
            }

            _context.Entry(comune).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComuneExists(id))
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

        // POST: api/Comuni
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comune>> PostComune(Comune comune)
        {
            if (_context.Comuni == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Comuni'  is null.");
            }
            _context.Comuni.Add(comune);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComune", new { id = comune.ComuneId }, comune);
        }

        // DELETE: api/Comuni/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComune(int id)
        {
            if (_context.Comuni == null)
            {
                return NotFound();
            }
            var comune = await _context.Comuni.FindAsync(id);
            if (comune == null)
            {
                return NotFound();
            }

            _context.Comuni.Remove(comune);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComuneExists(int id)
        {
            return (_context.Comuni?.Any(e => e.ComuneId == id)).GetValueOrDefault();
        }
    }
}
