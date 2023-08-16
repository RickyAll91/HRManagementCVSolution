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
    public class LivelloContrattualesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LivelloContrattualesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LivelloContrattuales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivelloContrattuale>>> GetLivelloContrattuales()
        {
            if (_context.LivelloContrattuales == null)
            {
                return NotFound();
            }
            return await _context.LivelloContrattuales.ToListAsync();
        }

        // GET: api/LivelloContrattuales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LivelloContrattuale>> GetLivelloContrattuale(int id)
        {
            if (_context.LivelloContrattuales == null)
            {
                return NotFound();
            }
            var livelloContrattuale = await _context.LivelloContrattuales.FindAsync(id);

            if (livelloContrattuale == null)
            {
                return NotFound();
            }

            return livelloContrattuale;
        }

        // PUT: api/LivelloContrattuales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivelloContrattuale(int id, LivelloContrattuale livelloContrattuale)
        {
            if (id != livelloContrattuale.LivelloContrattoId)
            {
                return BadRequest();
            }

            _context.Entry(livelloContrattuale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivelloContrattualeExists(id))
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

        // POST: api/LivelloContrattuales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LivelloContrattuale>> PostLivelloContrattuale(LivelloContrattuale livelloContrattuale)
        {
            if (_context.LivelloContrattuales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LivelloContrattuales'  is null.");
            }
            _context.LivelloContrattuales.Add(livelloContrattuale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivelloContrattuale", new { id = livelloContrattuale.LivelloContrattoId }, livelloContrattuale);
        }

        // DELETE: api/LivelloContrattuales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivelloContrattuale(int id)
        {
            if (_context.LivelloContrattuales == null)
            {
                return NotFound();
            }
            var livelloContrattuale = await _context.LivelloContrattuales.FindAsync(id);
            if (livelloContrattuale == null)
            {
                return NotFound();
            }

            _context.LivelloContrattuales.Remove(livelloContrattuale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivelloContrattualeExists(int id)
        {
            return (_context.LivelloContrattuales?.Any(e => e.LivelloContrattoId == id)).GetValueOrDefault();
        }
    }
}
