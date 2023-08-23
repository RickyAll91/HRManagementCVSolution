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
    [Route("api/[controller]")]
    [ApiController]
    public class SediController : ControllerBase
    {
        private readonly IApplicationRepository<Sede> repository;

        public SediController(IApplicationRepository<Sede> repository)
        {
            this.repository = repository;
        }

        // GET: api/Sedi
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSede()
        {
            if (repository.Context.Candidati == null!)
            {
                return NotFound();
            }
            IEnumerable<Sede> risultato = await repository.Context.Sedi
                .Include(s => s.ReferenteNavigation)
                .ToListAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }

            return Ok(risultato);
        }

        // GET: api/Sedi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSede(int id)
        {
            if (repository.Context.Candidati == null!)
            {
                return NotFound();
            }

            IEnumerable<Sede> risultato = await repository.Context.Sedi
                .Include(s => s.ReferenteNavigation)
                .AsSplitQuery()
                .ToListAsync();


            if (!risultato.Any())
            {
                return NotFound();
            }

            return Ok(risultato);
        }
        // PUT: api/Sedi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutSede(int id, Sede sede)
        {
            if (id != sede.SedeId)
            {
                return BadRequest();
            }

            try
            {
                await repository
                    .AggiornaAsync(sede);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeEsiste(id))
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

        // POST: api/Sedi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Sede>> PostSede(Sede sede)
        {
            if (repository.Context.Sedi == null!)
            {
                return Problem("L'entità ApplicationDbContext.Sedi è null.");
            }

            await repository
                .CreaAsync(sede);

            return CreatedAtAction("GetSede", new { id = sede.SedeId }, sede);
        }

        // DELETE: api/Sedi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            if (repository.Context.Candidati == null!)
            {
                return NotFound();
            }
            Sede? risultato = await repository
                .RecuperaByIdAsync(id);

            if (risultato == null)
            {
                return NotFound();
            }

            await repository.EliminaAsync(risultato);

            return NoContent();
        }

        private bool SedeEsiste(int id)
        {
            return (repository.Context.Candidati?.Any(e => e.CandidatoId == id))
                .GetValueOrDefault();
        }
    }
}