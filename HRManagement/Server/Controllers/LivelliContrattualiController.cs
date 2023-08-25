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
using NuGet.Protocol.Core.Types;
using HRManagement.Client.Pages;

namespace HRManagement.Server.Controllers
{
    [Route("api/livellicontratti")]
    [ApiController]
    public class LivelliContrattualiController : ControllerBase
    {
        private readonly IApplicationRepository<LivelloContrattuale> repository;

        public LivelliContrattualiController(IApplicationRepository<LivelloContrattuale> repository)
        {
            this.repository = repository;
        }

        // GET: api/LivelliContrattuali
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LivelloContrattuale>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<LivelloContrattuale>>> GetLivelliContratto()
        {
            if (repository.Context.LivelliContrattuali == null!)
            {
                return NotFound();
            }
            IEnumerable<LivelloContrattuale> risultato = await repository
                .RecuperaTuttoAsync();
            if (!risultato.Any())
            {
                return NotFound();
            }
            return Ok(risultato);
        }

        // GET: api/HardSkills/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LivelloContrattuale>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<HardSkill>> GetLivelloContratto(int id)
        {
            if (repository.Context.HardSkills == null!)
            {
                return NotFound();
            }
            LivelloContrattuale? query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<LivelloContrattuale?> risultato = new() 
            {
                query 
            };

            return Ok(risultato);
        }

        // PUT: api/HardSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutLivelloContratto(int id, LivelloContrattuale livelloContrattuale)
        {
            if (id != livelloContrattuale.Id)
            {
                return BadRequest();
            }
            try
            {
                await repository
                    .AggiornaAsync(livelloContrattuale);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivelloContrattoEsiste(id))
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

        // POST: api/HardSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<LivelloContrattuale>> PostLivelloContratto(LivelloContrattuale livelloContrattuale)
        {
            if (repository.Context.HardSkills == null!)
            {
                return Problem("L'entità ApplicationDbContext.LivelloContratto è null.");
            }

            await repository
                .CreaAsync(livelloContrattuale);

            return CreatedAtAction("GetLivelloContratto", new { id = livelloContrattuale.Id }, livelloContrattuale);
        }

        // DELETE: api/HardSkills/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteLivelloContratto(int id)
        {
            if (repository.Context.HardSkills == null!)
            {
                return NotFound();
            }
            LivelloContrattuale? risultato = await repository
                .RecuperaByIdAsync(id);

            if (risultato == null)
            {
                return NotFound();
            }

            await repository
                .EliminaAsync(risultato);

            return NoContent();
        }

        private bool LivelloContrattoEsiste(int id)
        {
            return (repository.Context.LivelliContrattuali?
                .Any(e => e.Id == id))
                .GetValueOrDefault();
        }
    }
}

