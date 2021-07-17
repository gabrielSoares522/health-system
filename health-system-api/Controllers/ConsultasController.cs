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
    public class ConsultasController : ControllerBase
    {
        private readonly Context _context;

        public ConsultasController(Context context)
        {
            _context = context;
        }

        // GET: api/Consultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultas()
        {
            return await _context.Consultas.ToListAsync();
        }

        // GET: api/Consultas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> GetConsulta(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            return consulta;
        }

        // PUT: api/Consultas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsulta(int id, Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return BadRequest();
            }

            _context.Entry(consulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaExists(id))
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

        // POST: api/Consultas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Consulta>> PostConsulta(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsulta", new { id = consulta.Id }, consulta);
        }

        // DELETE: api/Consultas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consulta>> DeleteConsulta(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return consulta;
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }
    }
}
