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
    [Route("api/benefits")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly IApplicationRepository<Benefit> repository;

        public BenefitsController(IApplicationRepository<Benefit> repository, ApplicationDbContext context)
        {
            this.repository = repository;
        }

        // GET: api/Benefits
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Benefit>>> GetBenefits()
        {
            if (repository.Context.Benefits == null!)
            {
                return NotFound();
            }

            List<Benefit> risultato = await repository
                .RecuperaTuttoAsync();

            return Ok(risultato);
        }

        // GET: api/Benefits/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Benefit>> GetBenefit(int id)
        {
            if (repository.Context.Benefits == null!)
            {
                return NotFound();
            }
            Benefit? query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<Benefit> risultato = new()
            {
                query
            };

            return Ok(risultato);
        }

        // PUT: api/Benefits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutBenefit(int id, Benefit benefit)
        {
            if (id != benefit.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository
                    .AggiornaAsync(benefit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenefitEsiste(id))
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

        // POST: api/Benefits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Benefit>> PostBenefit(Benefit benefit)
        {
            if (repository.Context.Benefits == null!)
            {
                return Problem("L'entità ApplicationDbContext.Benefits è null.");
            }

            await repository
                .CreaAsync(benefit);

            return CreatedAtAction("GetBenefit", new { id = benefit.Id }, benefit);
        }

        // DELETE: api/Benefits/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteBenefit(int id)
        {
            if (repository.Context.Benefits == null!)
            {
                return NotFound();
            }

            Benefit? risultato = await repository
                .RecuperaByIdAsync(id);

            if (risultato == null)
            {
                return NotFound();
            }

            await repository
                .EliminaAsync(risultato);

            return NoContent();
        }

        private bool BenefitEsiste(int id)
        {
            return (repository.Context.Benefits?.Any(e => e.Id == id))
                .GetValueOrDefault();
        }
    }
}
