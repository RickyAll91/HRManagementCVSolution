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
    public class TipologiaColloquiosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipologiaColloquiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipologiaColloquios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipologiaColloquio>>> GetTipologiaColloquios()
        {
            if (_context.TipologiaColloquios == null)
            {
                return NotFound();
            }
            return await _context.TipologiaColloquios.ToListAsync();
        }

        // GET: api/TipologiaColloquios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipologiaColloquio>> GetTipologiaColloquio(int id)
        {
            if (_context.TipologiaColloquios == null)
            {
                return NotFound();
            }
            var tipologiaColloquio = await _context.TipologiaColloquios.FindAsync(id);

            if (tipologiaColloquio == null)
            {
                return NotFound();
            }

            return tipologiaColloquio;
        }

        // PUT: api/TipologiaColloquios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipologiaColloquio(int id, TipologiaColloquio tipologiaColloquio)
        {
            if (id != tipologiaColloquio.TipoColloquioId)
            {
                return BadRequest();
            }

            _context.Entry(tipologiaColloquio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipologiaColloquioExists(id))
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

        // POST: api/TipologiaColloquios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipologiaColloquio>> PostTipologiaColloquio(TipologiaColloquio tipologiaColloquio)
        {
            if (_context.TipologiaColloquios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipologiaColloquios'  is null.");
            }
            _context.TipologiaColloquios.Add(tipologiaColloquio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipologiaColloquio", new { id = tipologiaColloquio.TipoColloquioId }, tipologiaColloquio);
        }

        // DELETE: api/TipologiaColloquios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipologiaColloquio(int id)
        {
            if (_context.TipologiaColloquios == null)
            {
                return NotFound();
            }
            var tipologiaColloquio = await _context.TipologiaColloquios.FindAsync(id);
            if (tipologiaColloquio == null)
            {
                return NotFound();
            }

            _context.TipologiaColloquios.Remove(tipologiaColloquio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipologiaColloquioExists(int id)
        {
            return (_context.TipologiaColloquios?.Any(e => e.TipoColloquioId == id)).GetValueOrDefault();
        }
    }
}
