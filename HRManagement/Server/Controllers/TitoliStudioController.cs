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
    [Route("api/[controller]")]
    [ApiController]
    public class TitoliStudioController : ControllerBase
    {
        IApplicationRepository<TitoloStudio> repository;

        public TitoliStudioController(IApplicationRepository<TitoloStudio> repository)
        {
            this.repository = repository;
        }

        // GET: api/TitoliStudio
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TitoloStudio>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<TitoloStudio>>> GetTitoliStudio()
        {
            if (repository.Context.TitoliStudio == null!)
            {
                return NotFound();
            }

            IEnumerable<TitoloStudio> risultato = await repository
                .RecuperaTuttoAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }
            return Ok(risultato);
        }


        // GET: api/TitoliStudio/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TitoloStudio>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TitoloStudio>> GetTitoloStudio(int id)
        {
            if (repository.Context.TitoliStudio == null!)
            {
                return NotFound();
            }
            TitoloStudio? query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<TitoloStudio?> risultato = new()
            {
                query
            };

            return Ok(risultato);
        }

        // PUT: api/TitoliStudio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutTitoloStudio(int id, TitoloStudio titoloStudio)
        {
            if (id != titoloStudio.TitoloStudioId)
            {
                return BadRequest();
            }

            try
            {
                await repository.AggiornaAsync(titoloStudio);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitoloStudioEsiste(id))
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

        // POST: api/TitoliStudio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<TitoloStudio>> PostTitoloStudio(TitoloStudio titoloStudio)
        {
            if (repository.Context.TitoliStudio == null!)
            {
                return Problem("L'entità ApplicationDbContext.TitoliStudio è null.");
            }

            await repository
                .CreaAsync(titoloStudio);

            return CreatedAtAction("GetTitoloStudio", new { id = titoloStudio.TitoloStudioId }, titoloStudio);
        }

        // DELETE: api/TitoliStudio/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTitoloStudio(int id)
        {
            if (repository.Context.TitoliStudio == null)
            {
                return NotFound();
            }
            TitoloStudio? titoloStudio = await repository
                .RecuperaByIdAsync(id);

            if (titoloStudio == null)
            {
                return NotFound();
            }

            await repository.EliminaAsync(titoloStudio);

            return NoContent();
        }

        private bool TitoloStudioEsiste(int id)
        {
            return (repository.Context.TitoliStudio?.Any(e => e.TitoloStudioId == id))
                .GetValueOrDefault();
        }
    }
}