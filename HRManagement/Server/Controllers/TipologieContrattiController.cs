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

namespace HRManagement.Server.Controllers
{
    [Route("api/tipologiecontratti")]
    [ApiController]
    public class TipologieContrattiController : ControllerBase
    {
        private readonly IApplicationRepository<TipologiaContratto> repository;

        public TipologieContrattiController(IApplicationRepository<TipologiaContratto> repository)
        {
            this.repository = repository;
        }

        // GET: api/TipologieContratti
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TipologiaColloquio>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<TipologiaContratto>>> GetTipologieContratti()
        {
            if (repository.Context.TipologieContratti == null!)
            {
                return NotFound();
            }

            List<TipologiaContratto> risultato = await repository
                .RecuperaTuttoAsync();
            if (!risultato.Any())
            {
                return NotFound();
            }
            return Ok(risultato);
        }

        // GET: api/TipologieContratti/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TipologiaColloquio>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<TipologiaContratto>>> GetTipologiaContratto(int id)
        {
            if (repository.Context.TipologieContratti == null!)
            {
                return NotFound();
            }
            var query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<TipologiaContratto> risultato = new()
            {
                query
            };

            return risultato;
        }

        // PUT: api/TipologieContratti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutTipologiaContratto(int id, TipologiaContratto tipologiaContratto)
        {
            if (id != tipologiaContratto.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository
                    .AggiornaAsync(tipologiaContratto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipologiaContrattoEsiste(id))
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

        // POST: api/TipologieContratti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TipologiaContratto>> PostTipologiaContratto(TipologiaContratto tipologiaContratto)
        {
            if (repository.Context.TipologieContratti == null!)
            {
                return Problem("L'entità ApplicationDbContext.TipologieContratti è null.");
            }

            await repository
                .CreaAsync(tipologiaContratto);

            return CreatedAtAction("GetTipologiaContratto", new { id = tipologiaContratto.Id }, tipologiaContratto);
        }

        // DELETE: api/TipologieContratti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipologiaContratto(int id)
        {
            if (repository.Context.TipologieContratti == null!)
            {
                return NotFound();
            }
            var risultato = await repository
                .RecuperaByIdAsync(id);
            if (risultato == null)
            {
                return NotFound();
            }

            await repository.EliminaAsync(risultato);

            return NoContent();
        }

        private bool TipologiaContrattoEsiste(int id)
        {
            return (repository.Context.TipologieContratti?
                .Any(e => e.Id == id))
                .GetValueOrDefault();
        }
    }
}
