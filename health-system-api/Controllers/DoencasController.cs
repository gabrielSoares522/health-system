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
    public class DoencasController : ControllerBase
    {
        private readonly Context _context;

        public DoencasController(Context context)
        {
            _context = context;
        }

        // GET: api/Doencas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doenca>>> GetDoencas()
        {
            return await _context.Doencas.ToListAsync();
        }

        // GET: api/Doencas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doenca>> GetDoenca(int id)
        {
            var doenca = await _context.Doencas.FindAsync(id);

            if (doenca == null)
            {
                return NotFound();
            }

            return doenca;
        }

        // PUT: api/Doencas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoenca(int id, Doenca doenca)
        {
            if (id != doenca.Id)
            {
                return BadRequest();
            }

            _context.Entry(doenca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoencaExists(id))
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

        // POST: api/Doencas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doenca>> PostDoenca(Doenca doenca)
        {
            _context.Doencas.Add(doenca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoenca", new { id = doenca.Id }, doenca);
        }

        // DELETE: api/Doencas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doenca>> DeleteDoenca(int id)
        {
            var doenca = await _context.Doencas.FindAsync(id);
            if (doenca == null)
            {
                return NotFound();
            }

            _context.Doencas.Remove(doenca);
            await _context.SaveChangesAsync();

            return doenca;
        }

        private bool DoencaExists(int id)
        {
            return _context.Doencas.Any(e => e.Id == id);
        }
    }
}
