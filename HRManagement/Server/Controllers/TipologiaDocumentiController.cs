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
    [Route("api/tipologiedocumenti")]
    [ApiController]
    public class TipologiaDocumentiController : ControllerBase
    {
        private readonly IApplicationRepository<TipologiaDocumento> repository;

        public TipologiaDocumentiController(IApplicationRepository<TipologiaDocumento> repository)
        {
            this.repository = repository;
        }

        // GET: api/TipologiaDocumenti
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TipologiaDocumento>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<TipologiaDocumento>>> GetTipiDocumento()
        {
            if (repository.Context.TipologieDocumenti == null!)
            {
                return NotFound();
            }

            IEnumerable<TipologiaDocumento> risultato = await repository
                .RecuperaTuttoAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }
            return Ok(risultato);
        }


        // GET: api/TipologiaDocumenti/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TipologiaDocumento>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TipologiaDocumento>> GetTipoDocumento(int id)
        {
            if (repository.Context.TitoliStudio == null!)
            {
                return NotFound();
            }
            TipologiaDocumento? query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<TipologiaDocumento?> risultato = new()
            {
                query
            };

            return Ok(risultato);
        }

        // PUT: api/TipologiaDocumenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutTipoDocumento(int id, TipologiaDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.AggiornaAsync(tipoDocumento);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocumentoEsiste(id))
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

        // POST: api/TipologiaDocumenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<TipologiaDocumento>> PostTipoDocumento(TipologiaDocumento tipoDocumento)
        {
            if (repository.Context.TipologieDocumenti == null!)
            {
                return Problem("L'entità ApplicationDbContext.TipologieDocumenti è null.");
            }

            await repository
                .CreaAsync(tipoDocumento);

            return CreatedAtAction("GetTipoDocumento", new { id = tipoDocumento.Id }, tipoDocumento);
        }

        // DELETE: api/TipologiaDocumenti/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTipoDocumento(int id)
        {
            if (repository.Context.TipologieDocumenti == null!)
            {
                return NotFound();
            }
            TipologiaDocumento? tipoDocumento = await repository
                .RecuperaByIdAsync(id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            await repository.EliminaAsync(tipoDocumento);

            return NoContent();
        }

        private bool TipoDocumentoEsiste(int id)
        {
            return (repository.Context.TipologieDocumenti?.Any(e => e.Id == id))
                .GetValueOrDefault();
        }
    }
}