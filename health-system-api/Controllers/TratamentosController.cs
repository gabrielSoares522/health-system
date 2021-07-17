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
    public class TratamentosController : ControllerBase
    {
        private readonly Context _context;

        public TratamentosController(Context context)
        {
            _context = context;
        }

        // GET: api/Tratamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tratamento>>> GetTratamentos()
        {
            return await _context.Tratamentos.ToListAsync();
        }

        // GET: api/Tratamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tratamento>> GetTratamento(int id)
        {
            var tratamento = await _context.Tratamentos.FindAsync(id);

            if (tratamento == null)
            {
                return NotFound();
            }

            return tratamento;
        }

        // PUT: api/Tratamentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTratamento(int id, Tratamento tratamento)
        {
            if (id != tratamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(tratamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TratamentoExists(id))
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

        // POST: api/Tratamentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tratamento>> PostTratamento(Tratamento tratamento)
        {
            _context.Tratamentos.Add(tratamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTratamento", new { id = tratamento.Id }, tratamento);
        }

        // DELETE: api/Tratamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tratamento>> DeleteTratamento(int id)
        {
            var tratamento = await _context.Tratamentos.FindAsync(id);
            if (tratamento == null)
            {
                return NotFound();
            }

            _context.Tratamentos.Remove(tratamento);
            await _context.SaveChangesAsync();

            return tratamento;
        }

        private bool TratamentoExists(int id)
        {
            return _context.Tratamentos.Any(e => e.Id == id);
        }
    }
}
