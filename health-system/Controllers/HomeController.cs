using health_system.Models;
using health_system_api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace health_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuario = await _context.Usuarios.Include(p => p.Consultas)
                .FirstOrDefaultAsync(m => m.Id.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (usuario.AutorizacaoId == 1)
                {
                    return RedirectToAction("Index", "Medico");
                }
                else {
                    return RedirectToAction("Index", "Administrador");
                }
            }
            else
            {

                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Nome,Email,Senha,Telefone,AutorizacaoId,CRM")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Email,string Senha)
        {
            var usuario = await _context.Usuarios.Include(p => p.Consultas)
                .FirstOrDefaultAsync(m => m.Email == Email && m.Senha == Senha);

            if(usuario != null)
            {
                int usuarioId = usuario.Id;
                string nome = usuario.Nome;

                List<Claim> direitosAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,usuarioId.ToString()),
                    new Claim(ClaimTypes.Name,nome)
                };

                var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.Now.AddHours(1)
                    });

                if(usuario.AutorizacaoId == 1) return RedirectToAction("Index", "Medico");
                else return RedirectToAction("Index", "Administrador");
            }
            else
            {
                return View();
            }
            
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index","Home");
        }
    }
}
