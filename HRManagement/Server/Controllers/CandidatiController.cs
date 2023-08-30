using HRManagement.Server.Data;
using HRManagement.Server.Repository;
using HRManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace HRManagement.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CandidatiController : ControllerBase
    {
        private readonly IApplicationRepository<Candidato> repository;

        public CandidatiController(IApplicationRepository<Candidato> repository)
        {
            this.repository = repository;
        }

        // GET: api/Candidatoes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidati()
        {
            if (repository.Context.Candidati == null!)
            {
                return NotFound();
            }
            IEnumerable<Candidato> risultato = await repository
                .RecuperaTuttoAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }

            return Ok(risultato);
        }

        // GET: api/Candidatoes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Candidato>>> GetCandidato(int id)
        {
            if (repository.Context.Candidati == null!)
            {
                return NotFound();
            }

            List<Candidato>? risultato = await repository.Context.Candidati
                .Include(e => e.HardSkillsCandidati)
                .ThenInclude(e => e.HardSkillNavigation)
                .Include(e => e.SoftSkillCandidati)
                .ThenInclude(e => e.SoftSkillNavigation)
                .Include(e => e.ResidenzaNavigation)
                .ThenInclude(e => e.ProvinciaNavigation)
                .Include(e => e.TipoContrattoNavigation)
                .Where(e => e.CandidatoId == id)
                .AsSplitQuery()
                .ToListAsync();
            if (risultato == null!)
            {
                return NotFound();
            }

            return Ok(risultato);
        }
        // PUT: api/Candidatoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (id != candidato.CandidatoId)
            {
                return BadRequest();
            }

            try
            {
                await repository
                    .AggiornaAsync(candidato);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
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

        // POST: api/Candidatoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Candidato>> PostCandidato(Candidato candidato)
        {
            if (repository.Context.Candidati == null)
            {
                return Problem("L'entità ApplicationDbContext.Candidati è null.");
            }

            await repository
                .CreaAsync(candidato);

            return CreatedAtAction("GetCandidato", new { id = candidato.CandidatoId }, candidato);
        }

        // DELETE: api/Candidatoes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            if (repository.Context.Candidati == null)
            {
                return NotFound();
            }
            Candidato? candidato = await repository
                .RecuperaByIdAsync(id);

            if (candidato == null)
            {
                return NotFound();
            }

            await repository.EliminaAsync(candidato);

            return NoContent();
        }

        private bool CandidatoExists(int id)
        {
            return (repository.Context.Candidati?.Any(e => e.CandidatoId == id))
                .GetValueOrDefault();
        }
    }
}