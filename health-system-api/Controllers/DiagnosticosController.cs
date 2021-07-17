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
    public class DiagnosticosController : ControllerBase
    {
        private readonly Context _context;

        public DiagnosticosController(Context context)
        {
            _context = context;
        }

        // GET: api/Diagnosticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diagnostico>>> GetDiagnosticos()
        {
            return await _context.Diagnosticos.ToListAsync();
        }

        // GET: api/Diagnosticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnostico>> GetDiagnostico(int id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(id);

            if (diagnostico == null)
            {
                return NotFound();
            }

            return diagnostico;
        }

        // PUT: api/Diagnosticos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnostico(int id, Diagnostico diagnostico)
        {
            if (id != diagnostico.DoencaId)
            {
                return BadRequest();
            }

            _context.Entry(diagnostico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosticoExists(id))
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

        // POST: api/Diagnosticos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Diagnostico>> PostDiagnostico(Diagnostico diagnostico)
        {
            _context.Diagnosticos.Add(diagnostico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiagnosticoExists(diagnostico.DoencaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiagnostico", new { id = diagnostico.DoencaId }, diagnostico);
        }

        // DELETE: api/Diagnosticos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diagnostico>> DeleteDiagnostico(int id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();

            return diagnostico;
        }

        private bool DiagnosticoExists(int id)
        {
            return _context.Diagnosticos.Any(e => e.DoencaId == id);
        }
    }
}
