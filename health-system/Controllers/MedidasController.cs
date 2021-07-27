using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using health_system_api.Models;

namespace health_system.Controllers
{
    public class MedidasController : Controller
    {
        private readonly Context _context;

        public MedidasController(Context context)
        {
            _context = context;
        }

        // GET: Medidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingestoes.ToListAsync());
        }

        // GET: Medidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medida = await _context.Ingestoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medida == null)
            {
                return NotFound();
            }

            return View(medida);
        }

        // GET: Medidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Medida medida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medida);
        }

        // GET: Medidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medida = await _context.Ingestoes.FindAsync(id);
            if (medida == null)
            {
                return NotFound();
            }
            return View(medida);
        }

        // POST: Medidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Medida medida)
        {
            if (id != medida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedidaExists(medida.Id))
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
            return View(medida);
        }

        // GET: Medidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medida = await _context.Ingestoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medida == null)
            {
                return NotFound();
            }

            return View(medida);
        }

        // POST: Medidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medida = await _context.Ingestoes.FindAsync(id);
            _context.Ingestoes.Remove(medida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedidaExists(int id)
        {
            return _context.Ingestoes.Any(e => e.Id == id);
        }
    }
}
