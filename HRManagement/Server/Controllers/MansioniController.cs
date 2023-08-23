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
    public class MansioniController : ControllerBase
    {
        private readonly IApplicationRepository<Mansione> repository;

        public MansioniController(IApplicationRepository<Mansione> repository)
        {
            this.repository = repository;
        }


        // GET: api/Mansioni
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Mansione>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<Mansione>>> GetMansioni()
        {
            if (repository.Context.Mansioni == null!)
            {
                return NotFound();
            }
            IEnumerable<Mansione> risultato = await repository
                .RecuperaTuttoAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }

            return Ok(risultato);
        }

        // GET: api/Mansioni/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HardSkill>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Mansione>> GetMansione(int id)
        {
            if (repository.Context.HardSkills == null!)
            {
                return NotFound();
            }
            Mansione? query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<Mansione> risultato = new()
            {
                query
            };

            return Ok(risultato);
        }

        // PUT: api/Mansioni/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutMansione(int id, Mansione mansione)
        {
            if (id != mansione.MansioneId)
            {
                return BadRequest();
            }
            try
            {
                await repository.AggiornaAsync(mansione);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MansioneEsiste(id))
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

        // POST: api/Mansioni
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Mansione>> PostMansione(Mansione mansione)
        {
            if (repository.Context.HardSkills == null!)
            {
                return Problem("L'entità ApplicationDbContext.Mansioni è null.");
            }

            await repository
                .CreaAsync(mansione);

            return CreatedAtAction("GetMansione", new { id = mansione.MansioneId }, mansione);
        }

        // DELETE: api/Mansioni/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMansione(int id)
        {
            if (repository.Context.Mansioni == null!)
            {
                return NotFound();
            }
            Mansione? risultato = await repository
                .RecuperaByIdAsync(id);

            if (risultato == null)
            {
                return NotFound();
            }

            await repository
                .EliminaAsync(risultato);

            return NoContent();
        }

        private bool MansioneEsiste(int id)
        {
            return (repository.Context.Mansioni?
                .Any(e => e.MansioneId== id))
                .GetValueOrDefault();
        }
    }
}