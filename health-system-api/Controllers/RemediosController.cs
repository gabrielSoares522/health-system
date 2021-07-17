using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using health_system_api.Models;

namespace health_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemediosController : ControllerBase
    {
        private readonly Context _context;

        public RemediosController(Context context)
        {
            _context = context;
        }

        // GET: api/Remedios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remedio>>> GetRemedios()
        {
            return await _context.Remedios.ToListAsync();
        }

        // GET: api/Remedios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Remedio>> GetRemedio(int id)
        {
            var remedio = await _context.Remedios.FindAsync(id);

            if (remedio == null)
            {
                return NotFound();
            }

            return remedio;
        }

        // PUT: api/Remedios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemedio(int id, Remedio remedio)
        {
            if (id != remedio.Id)
            {
                return BadRequest();
            }

            _context.Entry(remedio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemedioExists(id))
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

        // POST: api/Remedios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Remedio>> PostRemedio(Remedio remedio)
        {
            _context.Remedios.Add(remedio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRemedio", new { id = remedio.Id }, remedio);
        }

        // DELETE: api/Remedios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Remedio>> DeleteRemedio(int id)
        {
            var remedio = await _context.Remedios.FindAsync(id);
            if (remedio == null)
            {
                return NotFound();
            }

            _context.Remedios.Remove(remedio);
            await _context.SaveChangesAsync();

            return remedio;
        }

        private bool RemedioExists(int id)
        {
            return _context.Remedios.Any(e => e.Id == id);
        }
    }
}
