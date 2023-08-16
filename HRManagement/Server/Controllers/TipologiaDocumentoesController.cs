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
    public class TipologiaDocumentoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipologiaDocumentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipologiaDocumentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipologiaDocumento>>> GetTipologiaDocumentos()
        {
            if (_context.TipologiaDocumentos == null)
            {
                return NotFound();
            }
            return await _context.TipologiaDocumentos.ToListAsync();
        }

        // GET: api/TipologiaDocumentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipologiaDocumento>> GetTipologiaDocumento(int id)
        {
            if (_context.TipologiaDocumentos == null)
            {
                return NotFound();
            }
            var tipologiaDocumento = await _context.TipologiaDocumentos.FindAsync(id);

            if (tipologiaDocumento == null)
            {
                return NotFound();
            }

            return tipologiaDocumento;
        }

        // PUT: api/TipologiaDocumentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipologiaDocumento(int id, TipologiaDocumento tipologiaDocumento)
        {
            if (id != tipologiaDocumento.TipoDocumentoId)
            {
                return BadRequest();
            }

            _context.Entry(tipologiaDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipologiaDocumentoExists(id))
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

        // POST: api/TipologiaDocumentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipologiaDocumento>> PostTipologiaDocumento(TipologiaDocumento tipologiaDocumento)
        {
            if (_context.TipologiaDocumentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipologiaDocumentos'  is null.");
            }
            _context.TipologiaDocumentos.Add(tipologiaDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipologiaDocumento", new { id = tipologiaDocumento.TipoDocumentoId }, tipologiaDocumento);
        }

        // DELETE: api/TipologiaDocumentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipologiaDocumento(int id)
        {
            if (_context.TipologiaDocumentos == null)
            {
                return NotFound();
            }
            var tipologiaDocumento = await _context.TipologiaDocumentos.FindAsync(id);
            if (tipologiaDocumento == null)
            {
                return NotFound();
            }

            _context.TipologiaDocumentos.Remove(tipologiaDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipologiaDocumentoExists(int id)
        {
            return (_context.TipologiaDocumentos?.Any(e => e.TipoDocumentoId == id)).GetValueOrDefault();
        }
    }
}
