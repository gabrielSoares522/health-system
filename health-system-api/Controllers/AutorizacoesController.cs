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
    public class AutorizacoesController : ControllerBase
    {
        private readonly Context _context;

        public AutorizacoesController(Context context)
        {
            _context = context;
        }

        // GET: api/Autorizacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autorizacao>>> GetAutorizacao()
        {
            return await _context.Autorizacoes.ToListAsync();
        }

        // GET: api/Autorizacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autorizacao>> GetAutorizacao(int id)
        {
            var autorizacao = await _context.Autorizacoes.FindAsync(id);

            if (autorizacao == null)
            {
                return NotFound();
            }

            return autorizacao;
        }

        // PUT: api/Autorizacoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutorizacao(int id, Autorizacao autorizacao)
        {
            if (id != autorizacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(autorizacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorizacaoExists(id))
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

        // POST: api/Autorizacoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Autorizacao>> PostAutorizacao(Autorizacao autorizacao)
        {
            _context.Autorizacoes.Add(autorizacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutorizacao", new { id = autorizacao.Id }, autorizacao);
        }

        // DELETE: api/Autorizacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Autorizacao>> DeleteAutorizacao(int id)
        {
            var autorizacao = await _context.Autorizacoes.FindAsync(id);
            if (autorizacao == null)
            {
                return NotFound();
            }

            _context.Autorizacoes.Remove(autorizacao);
            await _context.SaveChangesAsync();

            return autorizacao;
        }

        private bool AutorizacaoExists(int id)
        {
            return _context.Autorizacoes.Any(e => e.Id == id);
        }
    }
}
