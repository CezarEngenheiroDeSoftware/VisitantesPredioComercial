using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    public class OcorrenciasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OcorrenciasController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var ListaDeOcorrencias = await _context.Ocorrencias.ToListAsync();
            return View(ListaDeOcorrencias);
        }
        public ActionResult cadastrar()
        {
            var ocorrencias = _context.Ocorrencias.ToList();
            ViewBag.ocorrencias = new SelectList(ocorrencias);
            return PartialView("cadastrar");
        }
        public async Task<IActionResult> CadastrarOcorrencia(Ocorrencias ocorrencias)
        {
            if(ModelState.IsValid)
            {
                await _context.Ocorrencias.AddAsync(ocorrencias);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        public async Task<IActionResult> ExcluirOcorrencia(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FirstOrDefaultAsync(a=>a.Id == id);
            if(ocorrencia != null && ocorrencia.Ativa != true)
            {
                _context.Ocorrencias.Remove(ocorrencia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
