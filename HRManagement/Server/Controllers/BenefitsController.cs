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
    public class BenefitsController : ControllerBase
    {
        private readonly IApplicationRepository<Benefit> repository;
        private readonly ApplicationDbContext _context;

        public BenefitsController(IApplicationRepository<Benefit> repository, ApplicationDbContext context)
        {
            this.repository = repository;
            _context = context;
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
        public async Task<ActionResult<Benefit>> GetBenefit(int id)
        {
            if (repository.Context.Benefits == null!)
            {
                return NotFound();
            }
            var query = await repository
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
            if (id != benefit.BenefitId)
            {
                return BadRequest();
            }

            try
            {
                await repository.AggiornaAsync(benefit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenefitExists(id))
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
        public async Task<ActionResult<Benefit>> PostBenefit(Benefit benefit)
        {
            if (_context.Benefits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Benefits'  is null.");
            }
            _context.Benefits.Add(benefit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenefit", new { id = benefit.BenefitId }, benefit);
        }

        // DELETE: api/Benefits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBenefit(int id)
        {
            if (_context.Benefits == null)
            {
                return NotFound();
            }
            var benefit = await _context.Benefits.FindAsync(id);
            if (benefit == null)
            {
                return NotFound();
            }

            _context.Benefits.Remove(benefit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BenefitExists(int id)
        {
            return (_context.Benefits?.Any(e => e.BenefitId == id)).GetValueOrDefault();
        }
    }
}
