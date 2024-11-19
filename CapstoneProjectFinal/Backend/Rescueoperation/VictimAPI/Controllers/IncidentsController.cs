using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VictimAPI.Data;
using VictimAPI.Models;

namespace VictimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly VictimContext _context;

        public IncidentsController(VictimContext context)
        {
            _context = context;
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentTbl>>> GetIncidents()
        {
            return await _context.IncidentTbls.ToListAsync();
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentTbl>> GetIncident(int id)
        {
            var incident = await _context.IncidentTbls.FindAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // PUT: api/Incidents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(int id, IncidentTbl incident)
        {
            if (id != incident.Id)
            {
                return BadRequest();
            }

            _context.Entry(incident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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

        // POST: api/Incidents
        [HttpPost]
        public async Task<ActionResult<IncidentTbl>> PostIncident(IncidentTbl incident)
        {
            _context.IncidentTbls.Add(incident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncident", new { id = incident.Id }, incident);
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(int id)
        {
            var incident = await _context.IncidentTbls.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            _context.IncidentTbls.Remove(incident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentExists(int id)
        {
            return _context.IncidentTbls.Any(e => e.Id == id);
        }
    }
}
