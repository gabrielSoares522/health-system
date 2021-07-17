﻿using System;
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
    public class MedidasController : ControllerBase
    {
        private readonly Context _context;

        public MedidasController(Context context)
        {
            _context = context;
        }

        // GET: api/Medidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medida>>> GetIngestoes()
        {
            return await _context.Ingestoes.ToListAsync();
        }

        // GET: api/Medidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medida>> GetMedida(int id)
        {
            var medida = await _context.Ingestoes.FindAsync(id);

            if (medida == null)
            {
                return NotFound();
            }

            return medida;
        }

        // PUT: api/Medidas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedida(int id, Medida medida)
        {
            if (id != medida.Id)
            {
                return BadRequest();
            }

            _context.Entry(medida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidaExists(id))
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

        // POST: api/Medidas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medida>> PostMedida(Medida medida)
        {
            _context.Ingestoes.Add(medida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedida", new { id = medida.Id }, medida);
        }

        // DELETE: api/Medidas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medida>> DeleteMedida(int id)
        {
            var medida = await _context.Ingestoes.FindAsync(id);
            if (medida == null)
            {
                return NotFound();
            }

            _context.Ingestoes.Remove(medida);
            await _context.SaveChangesAsync();

            return medida;
        }

        private bool MedidaExists(int id)
        {
            return _context.Ingestoes.Any(e => e.Id == id);
        }
    }
}
