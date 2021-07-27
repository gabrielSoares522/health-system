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
    public class AutorizacoesController : Controller
    {
        private readonly Context _context;

        public AutorizacoesController(Context context)
        {
            _context = context;
        }

        // GET: Autorizacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autorizacoes.ToListAsync());
        }

        // GET: Autorizacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorizacao = await _context.Autorizacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autorizacao == null)
            {
                return NotFound();
            }

            return View(autorizacao);
        }

        // GET: Autorizacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autorizacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Autorizacao autorizacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorizacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autorizacao);
        }

        // GET: Autorizacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorizacao = await _context.Autorizacoes.FindAsync(id);
            if (autorizacao == null)
            {
                return NotFound();
            }
            return View(autorizacao);
        }

        // POST: Autorizacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Autorizacao autorizacao)
        {
            if (id != autorizacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorizacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorizacaoExists(autorizacao.Id))
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
            return View(autorizacao);
        }

        // GET: Autorizacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorizacao = await _context.Autorizacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autorizacao == null)
            {
                return NotFound();
            }

            return View(autorizacao);
        }

        // POST: Autorizacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorizacao = await _context.Autorizacoes.FindAsync(id);
            _context.Autorizacoes.Remove(autorizacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorizacaoExists(int id)
        {
            return _context.Autorizacoes.Any(e => e.Id == id);
        }
    }
}
