using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagement.Server.Data;
using HRManagement.Shared.Models;
using HRManagement.Server.Repository;

namespace HRManagement.Server.Controllers
{
    [Route("api/colloqui")]
    [ApiController]
    public class ColloquiController : ControllerBase
    {
        private readonly IApplicationRepository<Colloquio> repository;

        public ColloquiController(IApplicationRepository<Colloquio> repository)
        {
            this.repository = repository;
        }

        // GET: api/Colloqui
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Colloquio>>> GetColloquios()
        {
            if (repository.Context.Colloqui == null!)
            {
                return NotFound();
            }

            var risultato = await repository.Context.Colloqui
                .Include(e => e.CandidatoNavigation)
                .Include(e => e.ReferenteTecnicoNavigation)
                .Include(e => e.HRNavigation)
                .Include(e => e.TipologiaColloquioNavigation)
                .Include(e => e.SedeColloquioNavigation)
                .ToListAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }

            return Ok(risultato);
        }

        // GET: api/Colloqui/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Colloquio>>> GetColloquio(int id)
        {
            if (repository.Context.Colloqui == null!)
            {
                return NotFound();
            }
            var risposta = await repository.Context.Colloqui
                .Include(e => e.CandidatoNavigation)
                .Include(e => e.ReferenteTecnicoNavigation)
                .Include(e => e.HRNavigation)
                .Include(e => e.TipologiaColloquioNavigation)
                .Include(e => e.SedeColloquioNavigation)
                .Where(p => p.ColloquioId == id)
                .ToListAsync();

            if (risposta == null!)
            {
                return NotFound();
            }

            return risposta;
        }

        // PUT: api/Colloqui/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutColloquio(int id, Colloquio colloquio)
        {
            if (id != colloquio.ColloquioId)
            {
                return BadRequest();
            }

            try
            {
                await repository.AggiornaAsync(colloquio);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColloquioEsiste(id))
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Colloquio>> PostColloquio(Colloquio colloquio)
        {
            if (repository.Context.Colloqui == null!)
            {
                return Problem("L'entità ApplicationDbContext.Colloqui è null.");
            }

            await repository.CreaAsync(colloquio);

            return CreatedAtAction("GetColloquio", new { id = colloquio.ColloquioId }, colloquio);
        }

        // DELETE: api/Colloqui/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteColloquio(int id)
        {
            if (repository.Context.Colloqui == null!)
            {
                return NotFound();
            }
            var colloquio = await repository.RecuperaByIdAsync(id);

            if (colloquio == null!)
            {
                return NotFound();
            }

            await repository.EliminaAsync(colloquio);

            return NoContent();
        }

        private bool ColloquioEsiste(int id)
        {
            return (repository.Context.Colloqui?.Any(e => e.ColloquioId == id)).GetValueOrDefault();
        }
    }
}
