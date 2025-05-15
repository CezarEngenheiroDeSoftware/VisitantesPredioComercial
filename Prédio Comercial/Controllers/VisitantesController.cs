using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    public class VisitantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VisitantesController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaVisitantes()
        {
            return View(await _context.Visitantes.ToListAsync());
        }

        public async Task<IActionResult> NovoVisitante(Visitantes visitantes)
        {
            if(ModelState.IsValid)
            {
                _context.Visitantes.Add(visitantes);
                await _context.SaveChangesAsync();
                return View("Index");
            }
            return BadRequest("Nâo foi possível cadastrar o novo visitante");
        }
    }
}
