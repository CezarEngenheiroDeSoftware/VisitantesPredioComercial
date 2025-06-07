using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.ActionFilter;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    [PaginaParaUsuarioAdmin]
    public class AcessosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFiltragemDePagina _filtragemDePagina;
        public AcessosController(ApplicationDbContext applicationDbContext, IFiltragemDePagina filtragemDePagina)
        {
            _context = applicationDbContext;
            _filtragemDePagina = filtragemDePagina;
        }

        public async Task<IActionResult> Index()
        {
            var Acesso = await _context.Acessos.Include(x=>x.Usuarios).Include(x=>x.Visitante).ToListAsync();
            return View(Acesso);
        }
  
        public async Task<IActionResult> Details(int id)
        {
            var Visitante = new SelectList(await _context.Visitantes.ToListAsync(), "Id", "Name");
            var Usuarios = new SelectList(await _context.Usuarios.ToListAsync(), "Id", "Login");
            ViewBag.Visitante = Visitante;
            ViewBag.Usuarios = Usuarios;    
            var acessoId = await _context.Acessos.FindAsync(id);
            return PartialView(acessoId);
        }
        public async Task<IActionResult> Criar()
        {
            var acesso = _filtragemDePagina.Buscar();
            if(acesso == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Visitantes = new SelectList(await _context.Visitantes.ToListAsync(), "Id", "Name");
            ViewBag.Usuarios = new SelectList(await _context.Usuarios.ToListAsync(), "Id", "Login");

            return View();
        }

        public async Task<IActionResult> CriarAcesso(Acessos acessos)
        {
            if (ModelState.IsValid)
            {
                var _NewAcesso = await _context.Acessos.AddAsync(acessos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Visitantes = new SelectList(await _context.Visitantes.ToListAsync(), "Id", "Name");
            ViewBag.Usuarios = new SelectList(await _context.Usuarios.ToListAsync(), "Id", "Login");
            return View("Criar", acessos);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var acesso = await _context.Acessos.FindAsync(id);
            return View(acesso);
        }

        public async Task<IActionResult> Editar(int id, Acessos acessos)
        {
            var acesso = await _context.Acessos.FindAsync(id);
            acessos.id = acesso.id;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
