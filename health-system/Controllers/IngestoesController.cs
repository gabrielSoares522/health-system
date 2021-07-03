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
    public class IngestoesController : Controller
    {
        private readonly Context _context;

        public IngestoesController(Context context)
        {
            _context = context;
        }

        // GET: Ingestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingestoes.ToListAsync());
        }

        // GET: Ingestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingestao = await _context.Ingestoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingestao == null)
            {
                return NotFound();
            }

            return View(ingestao);
        }

        // GET: Ingestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Ingestao ingestao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingestao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingestao);
        }

        // GET: Ingestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingestao = await _context.Ingestoes.FindAsync(id);
            if (ingestao == null)
            {
                return NotFound();
            }
            return View(ingestao);
        }

        // POST: Ingestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Ingestao ingestao)
        {
            if (id != ingestao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingestao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngestaoExists(ingestao.Id))
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
            return View(ingestao);
        }

        // GET: Ingestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingestao = await _context.Ingestoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingestao == null)
            {
                return NotFound();
            }

            return View(ingestao);
        }

        // POST: Ingestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingestao = await _context.Ingestoes.FindAsync(id);
            _context.Ingestoes.Remove(ingestao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngestaoExists(int id)
        {
            return _context.Ingestoes.Any(e => e.Id == id);
        }
    }
}
