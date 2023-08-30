using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagement.Server.Data;
using HRManagement.Server.Repository;
using HRManagement.Shared.Models;
using System.Data.OleDb;

namespace HRManagement.Server.Controllers
{
    [Route("api/esperienze")]
    [ApiController]
    public class EsperienzeLavorativeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationRepository<EsperienzaLavorativa> repository;

        public EsperienzeLavorativeController(ApplicationDbContext context, IApplicationRepository<EsperienzaLavorativa> repository)
        {
            _context = context;
            this.repository = repository;
        }

        // GET: api/EsperienzeLavorative
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<EsperienzaLavorativa>>> GetEsperienze()
        {
            if (repository.Context.Esperienze == null!)
            {
                return NotFound();
            }
            var risultato = await repository.Context.Esperienze
                .Include(p => p.MansioneNavigation)
                .ToListAsync();
            return Ok(risultato);
        }

        // GET: api/EsperienzeLavorative/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EsperienzaLavorativa>>> GetEsperienzaLavorativa(int id)
        {
            if (repository.Context.Esperienze == null!)
            {
                return NotFound();
            }
            EsperienzaLavorativa? esperienzaLavorativa = await repository.RecuperaByIdAsync(id);

            if (esperienzaLavorativa == null)
            {
                return NotFound();
            }
            List<EsperienzaLavorativa> risultato = new()
            {
                esperienzaLavorativa
            };

            return Ok(risultato);
        }

        // PUT: api/EsperienzeLavorative/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutEsperienzaLavorativa(int id, EsperienzaLavorativa esperienzaLavorativa)
        {
            if (id != esperienzaLavorativa.Id)
            {
                return BadRequest();
            }

            _context.Entry(esperienzaLavorativa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EsperienzaLavorativaExists(id))
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

        // POST: api/EsperienzeLavorative
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EsperienzaLavorativa>> PostEsperienzaLavorativa(EsperienzaLavorativa esperienzaLavorativa)
        {
            if (repository.Context.Esperienze == null!)
            {
                return Problem("L' entità ApplicationDbContext.Esperienze è null);");
            }

            await repository.CreaAsync(esperienzaLavorativa);

            return CreatedAtAction("GetEsperienzaLavorativa", new { id = esperienzaLavorativa.Id }, esperienzaLavorativa);
        }

        // DELETE: api/EsperienzeLavorative/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteEsperienzaLavorativa(int idEntitàPadre)
        {
            if (repository.Context.Esperienze == null!)
            {
                return NotFound();
            }

            repository.Context.Esperienze
                .RemoveRange(repository.Context.Esperienze
                    .Where(p => p.Candidato == idEntitàPadre)
                );
            await repository.Context.SaveChangesAsync();

            return NoContent();
        }

        private bool EsperienzaLavorativaExists(int id)
        {
            return (_context.Esperienze?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
