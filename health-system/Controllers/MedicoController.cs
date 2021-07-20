using health_system_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace health_system.Controllers
{
    public class MedicoController : Controller
    {
        private readonly Context _context;

        public MedicoController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.Pacientes.Include(p => p.Consultas);
            return View(await context.ToListAsync());
        }


        public IActionResult CadastroPaciente()
        {
            return View();
        }

        public async Task<IActionResult> CadastroConsulta(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var paciente = await _context.Pacientes.Include(p => p.Consultas)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (paciente == null) {
                return NotFound();
            }

            return View(paciente);
        }
    }
}
