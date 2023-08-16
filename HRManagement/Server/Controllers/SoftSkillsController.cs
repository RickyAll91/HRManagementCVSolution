using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagement.Server.Data;
using HRManagement.Shared.Models;

namespace HRManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SoftSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SoftSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftSkill>>> GetSoftSkills()
        {
            if (_context.SoftSkills == null)
            {
                return NotFound();
            }
            return await _context.SoftSkills.ToListAsync();
        }

        // GET: api/SoftSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoftSkill>> GetSoftSkill(int id)
        {
            if (_context.SoftSkills == null)
            {
                return NotFound();
            }
            var softSkill = await _context.SoftSkills.FindAsync(id);

            if (softSkill == null)
            {
                return NotFound();
            }

            return softSkill;
        }

        // PUT: api/SoftSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftSkill(int id, SoftSkill softSkill)
        {
            if (id != softSkill.SoftSkillId)
            {
                return BadRequest();
            }

            _context.Entry(softSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftSkillExists(id))
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

        // POST: api/SoftSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoftSkill>> PostSoftSkill(SoftSkill softSkill)
        {
            if (_context.SoftSkills == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SoftSkills'  is null.");
            }
            _context.SoftSkills.Add(softSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoftSkill", new { id = softSkill.SoftSkillId }, softSkill);
        }

        // DELETE: api/SoftSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftSkill(int id)
        {
            if (_context.SoftSkills == null)
            {
                return NotFound();
            }
            var softSkill = await _context.SoftSkills.FindAsync(id);
            if (softSkill == null)
            {
                return NotFound();
            }

            _context.SoftSkills.Remove(softSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoftSkillExists(int id)
        {
            return (_context.SoftSkills?.Any(e => e.SoftSkillId == id)).GetValueOrDefault();
        }
    }
}
