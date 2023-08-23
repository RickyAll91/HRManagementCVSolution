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
    public class TipologieColloquiController : ControllerBase
    {
        private readonly IApplicationRepository<TipologiaColloquio> repository;

        public TipologieColloquiController(IApplicationRepository<TipologiaColloquio> repository)
        {
            this.repository = repository;
        }

        // GET: api/TipologieColloqui
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TipologiaColloquio>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<TipologiaColloquio>>> GetTipiColloquio()
        {
            if (repository.Context.TipologieColloqui == null!)
            {
                return NotFound();
            }

            IEnumerable<TipologiaColloquio> risultato = await repository
                .RecuperaTuttoAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }
            return Ok(risultato);
        }


        // GET: api/TipologieColloqui/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TipologiaColloquio>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TipologiaColloquio>> GetTipoColloquio(int id)
        {
            if (repository.Context.TipologieColloqui == null!)
            {
                return NotFound();
            }
            TipologiaColloquio? query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<TipologiaColloquio> risultato = new()
            {
                query
            };

            return Ok(risultato);
        }

        // PUT: api/TipologieColloqui/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutTipoColloquio(int id, TipologiaColloquio tipoColloquio)
        {
            if (id != tipoColloquio.TipoColloquioId)
            {
                return BadRequest();
            }

            try
            {
                await repository.AggiornaAsync(tipoColloquio);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoColloquioEsiste(id))
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

        // POST: api/TipologieColloqui
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<TipologiaColloquio>> PostTipoColloquio(TipologiaColloquio tipoColloquio)
        {
            if (repository.Context.TipologieColloqui == null!)
            {
                return Problem("L'entità ApplicationDbContext.TipologieColloqui è null.");
            }

            await repository
                .CreaAsync(tipoColloquio);

            return CreatedAtAction("GetTipoColloquio", new { id = tipoColloquio.TipoColloquioId }, tipoColloquio);
        }

        // DELETE: api/TipologieColloqui/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTipoColloquio(int id)
        {
            if (repository.Context.TipologieColloqui == null!)
            {
                return NotFound();
            }
            TipologiaColloquio? tipoColloquio = await repository
                .RecuperaByIdAsync(id);

            if (tipoColloquio == null)
            {
                return NotFound();
            }

            await repository.EliminaAsync(tipoColloquio);

            return NoContent();
        }

        private bool TipoColloquioEsiste(int id)
        {
            return (repository.Context.TipologieColloqui?.Any(e => e.TipoColloquioId == id))
                .GetValueOrDefault();
        }
    }
}