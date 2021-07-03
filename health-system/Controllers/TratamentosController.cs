using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using health_system.Models;

namespace health_system.Controllers
{
    public class TratamentosController : Controller
    {
        private readonly Context _context;

        public TratamentosController(Context context)
        {
            _context = context;
        }

        // GET: Tratamentos
        public async Task<IActionResult> Index()
        {
            var context = _context.Tratamentos.Include(t => t.Consulta).Include(t => t.Remedio);
            return View(await context.ToListAsync());
        }

        // GET: Tratamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos
                .Include(t => t.Consulta)
                .Include(t => t.Remedio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamento == null)
            {
                return NotFound();
            }

            return View(tratamento);
        }

        // GET: Tratamentos/Create
        public IActionResult Create()
        {
            ViewData["ConsultaId"] = new SelectList(_context.Consultas, "Id", "Id");
            ViewData["RemedioId"] = new SelectList(_context.Remedios, "Id", "Id");
            return View();
        }

        // POST: Tratamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,qtDiasDuracao,Observacao,qtHorasIntervalo,qtDose,ConsultaId,RemedioId")] Tratamento tratamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consultas, "Id", "Id", tratamento.ConsultaId);
            ViewData["RemedioId"] = new SelectList(_context.Remedios, "Id", "Id", tratamento.RemedioId);
            return View(tratamento);
        }

        // GET: Tratamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos.FindAsync(id);
            if (tratamento == null)
            {
                return NotFound();
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consultas, "Id", "Id", tratamento.ConsultaId);
            ViewData["RemedioId"] = new SelectList(_context.Remedios, "Id", "Id", tratamento.RemedioId);
            return View(tratamento);
        }

        // POST: Tratamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,qtDiasDuracao,Observacao,qtHorasIntervalo,qtDose,ConsultaId,RemedioId")] Tratamento tratamento)
        {
            if (id != tratamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamentoExists(tratamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consultas, "Id", "Id", tratamento.ConsultaId);
            ViewData["RemedioId"] = new SelectList(_context.Remedios, "Id", "Id", tratamento.RemedioId);
            return View(tratamento);
        }

        // GET: Tratamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos
                .Include(t => t.Consulta)
                .Include(t => t.Remedio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamento == null)
            {
                return NotFound();
            }

            return View(tratamento);
        }

        // POST: Tratamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tratamento = await _context.Tratamentos.FindAsync(id);
            _context.Tratamentos.Remove(tratamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamentoExists(int id)
        {
            return _context.Tratamentos.Any(e => e.Id == id);
        }
    }
}
