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

namespace HRManagement.Server.Controllers
{
    [Route("api/hardskills")]
    [ApiController]
    public class HardSkillsController : ControllerBase
    {
        private readonly IApplicationRepository<HardSkill> repository;

        public HardSkillsController(IApplicationRepository<HardSkill> repository)
        {
            this.repository = repository;
        }

        // GET: api/HardSkills
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HardSkill>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<HardSkill>>> GetHardSkills()
        {
            if (repository.Context == null!)
            {
                return NotFound();
            }
            IEnumerable<HardSkill> risultato = await repository
                .RecuperaTuttoAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }

            return Ok(risultato);
        }

        // GET: api/HardSkills/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HardSkill>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<HardSkill>> GetHardSkill(int id)
        {
            if (repository.Context.HardSkills == null!)
            {
                return NotFound();
            }
            HardSkill? query = await repository
                .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<HardSkill> risultato = new()
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
        public async Task<IActionResult> PutHardSkill(int id, HardSkill hardSkill)
        {
            if (id != hardSkill.Id)
            {
                return BadRequest();
            }
            try
            {
                await repository.AggiornaAsync(hardSkill);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HardSkillEsiste(id))
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
        public async Task<ActionResult<HardSkill>> PostHardSkill(HardSkill hardSkill)
        {
            if (repository.Context.HardSkills == null!)
            {
                return Problem("L'entità ApplicationDbContext.HardSkills è null.");
            }

            await repository
                .CreaAsync(hardSkill);

            return CreatedAtAction("GetHardSkill", new { id = hardSkill.Id }, hardSkill);
        }

        // DELETE: api/HardSkills/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteHardSkill(int id)
        {
            if (repository.Context.HardSkills == null!)
            {
                return NotFound();
            }
            HardSkill? risultato = await repository
                .RecuperaByIdAsync(id);

            if (risultato == null)
            {
                return NotFound();
            }

            await repository
                .EliminaAsync(risultato);

            return NoContent();
        }

        private bool HardSkillEsiste(int id)
        {
            return (repository.Context.HardSkills?
                .Any(e => e.Id == id))
                .GetValueOrDefault();
        }
    }
}
