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
    public class MedicosController : Controller
    {

        private readonly Context _context;
        public MedicosController(Context context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {
            var context = _context.Medicos.Include(m => m.Hospital);
            return View(await context.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) { return NotFound(); }

            var medico = await _context.Medicos
                .Include(m => m.Hospital)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medico == null) { return NotFound(); }

            return View(medico);
        }

        // GET: Medicos/Create
        public IActionResult Create() {
            ViewData["HospitalId"] = new SelectList(_context.Hospitais, "Id", "Id");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,Telefone,HospitalId")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitais, "Id", "Id", medico.HospitalId);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null) { return NotFound(); }

            ViewData["HospitalId"] = new SelectList(_context.Hospitais, "Id", "Id", medico.HospitalId);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,Telefone,HospitalId")] Medico medico)
        {
            if (id != medico.Id) { return NotFound(); }

            if (ModelState.IsValid) {
                try {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MedicoExists(medico.Id)) { return NotFound(); }
                    else { throw; }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitais, "Id", "Id", medico.HospitalId);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }

            var medico = await _context.Medicos
                .Include(m => m.Hospital)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medico == null) { return NotFound(); }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
