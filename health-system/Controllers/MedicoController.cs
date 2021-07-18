using health_system_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace health_system.Controllers
{
    public class MedicoController : Controller
    {
        private readonly Context _context;

        public MedicoController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CadastroPacienteAsync()
        {
            var context = _context.Pacientes.Include(p => p);
            return View(await context.ToListAsync());
        }
    }
}
