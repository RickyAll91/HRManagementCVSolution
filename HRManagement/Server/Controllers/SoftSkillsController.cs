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
    [Route("api/softskills")]
    [ApiController]
    public class SoftSkillsController : ControllerBase
    {
        private readonly IApplicationRepository<SoftSkill> repository;

        public SoftSkillsController(IApplicationRepository<SoftSkill> repository)
        {
            this.repository = repository;
        }

        // GET: api/SoftSkills
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SoftSkill>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<SoftSkill>>> GetSoftSkills()
        {
            if (repository.Context.SoftSkills == null!)
            {
                return NotFound();
            }

            IEnumerable<SoftSkill> risultato = await repository
                .RecuperaTuttoAsync();

            if (!risultato.Any())
            {
                return NotFound();
            }
            return Ok(risultato);
        }


        // GET: api/SoftSkills/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SoftSkill>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SoftSkill>> GetSoftSkill(int id)
        {
            if (repository.Context.SoftSkills == null!)
            {
                return NotFound();
            }
            SoftSkill? query = await repository
                  .RecuperaByIdAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            List<SoftSkill?> risultato = new()
            {
                query
            };

            return Ok(risultato);
        }

        // PUT: api/SoftSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutSoftSkill(int id, SoftSkill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.AggiornaAsync(skill);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftSkillEsiste(id))
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
        public async Task<ActionResult<SoftSkill>> PostTitoloStudio(SoftSkill skill)
        {
            if (repository.Context.SoftSkills == null!)
            {
                return Problem("L'entità ApplicationDbContext.SoftSkills è null.");
            }

            await repository
                .CreaAsync(skill);

            return CreatedAtAction("GetSoftSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/TitoliStudio/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSoftSkill(int id)
        {
            if (repository.Context.SoftSkills == null!)
            {
                return NotFound();
            }
            SoftSkill? skill = await repository
                .RecuperaByIdAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            await repository.EliminaAsync(skill);

            return NoContent();
        }

        private bool SoftSkillEsiste(int id)
        {
            return (repository.Context.SoftSkills?.Any(e => e.Id == id))
                .GetValueOrDefault();
        }
    }
}
