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
    public class ContrattoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContrattoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Contrattoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contratto>>> GetContrattos()
        {
            if (_context.Contrattos == null)
            {
                return NotFound();
            }
            return await _context.Contrattos.ToListAsync();
        }

        // GET: api/Contrattoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contratto>> GetContratto(int id)
        {
            if (_context.Contrattos == null)
            {
                return NotFound();
            }
            var contratto = await _context.Contrattos.FindAsync(id);

            if (contratto == null)
            {
                return NotFound();
            }

            return contratto;
        }

        // PUT: api/Contrattoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContratto(int id, Contratto contratto)
        {
            if (id != contratto.ContrattoId)
            {
                return BadRequest();
            }

            _context.Entry(contratto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContrattoExists(id))
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

        // POST: api/Contrattoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contratto>> PostContratto(Contratto contratto)
        {
            if (_context.Contrattos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contrattos'  is null.");
            }
            _context.Contrattos.Add(contratto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContratto", new { id = contratto.ContrattoId }, contratto);
        }

        // DELETE: api/Contrattoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContratto(int id)
        {
            if (_context.Contrattos == null)
            {
                return NotFound();
            }
            var contratto = await _context.Contrattos.FindAsync(id);
            if (contratto == null)
            {
                return NotFound();
            }

            _context.Contrattos.Remove(contratto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContrattoExists(int id)
        {
            return (_context.Contrattos?.Any(e => e.ContrattoId == id)).GetValueOrDefault();
        }
    }
}
