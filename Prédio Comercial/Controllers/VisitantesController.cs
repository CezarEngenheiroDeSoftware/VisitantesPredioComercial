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
            //var visitasAtivas = await _context.Visitantes.Where(x=>x.DataSaida == null).ToListAsync();
            //return View(visitasAtivas);
            
            return View(await _context.Visitantes.ToListAsync());
        }
        public async Task<IActionResult> ListaVisitantesAtivo()
        {
            var visitantesAtivos = await _context.Visitantes.Where(x=>x.DataSaida == null).ToListAsync();
            if (visitantesAtivos == null) return BadRequest();
            return View(visitantesAtivos);
        }

        public async Task<IActionResult> NovoVisitante(Visitantes visitantes)
        {
            if(ModelState.IsValid)
            {
                _context.Visitantes.Add(visitantes);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListaVisitantes");
            }
            return BadRequest("Nâo foi possível cadastrar o novo visitante");
        }
        public async Task<IActionResult> BuscarPorId(int? id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            return View(visitante);
        }
        public async Task<IActionResult> Editar(int? id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            return PartialView("Editar", visitante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Visitantes visitantes)
        {
            if (id == null) return BadRequest();
            if(ModelState.IsValid)
            {
                _context.Visitantes.Update(visitantes);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Não foi possível Editar o cadastro");
        }
        [HttpPost]
        public async Task<IActionResult> DarSaida(int? id, [Bind("Id,DataSaida")] Visitantes visitantes)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null) return BadRequest();
            visitante.DataSaida = visitantes.DataSaida;
            await _context.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> DarSaidaView(int? id)
        {
            var saindoVisita = await _context.Visitantes.FindAsync(id);
            return PartialView("DarSaida", saindoVisita);
        }
        public async Task<IActionResult> Deletar(int? id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            if(visitante == null) return BadRequest();
            return PartialView("Deletar", visitante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarVisitante(int? id)
        {
            if (id == null) return BadRequest();

            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null) return NotFound();

            _context.Visitantes.Remove(visitante);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
