using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prédio_Comercial.Controllers
{
    public class ProprietariosController : Controller
    {
        private readonly IProprietarios _proprietarios;
        private readonly ApplicationDbContext _contex;
        private readonly ISessionUsuary _sessionUsuary;
        public ProprietariosController(IProprietarios proprietarios, ApplicationDbContext contex, ISessionUsuary sessionUsuary)
        {
            _proprietarios = proprietarios;
            _contex = contex;
            _sessionUsuary = sessionUsuary;
        }
        public async Task<IActionResult> Index()
        {
            //await _contex.Visitantes.ToListAsync();   
            return View(await _proprietarios.BuscarTodosProprietarios());
        }
        public IActionResult Detalhes()
        {
            return View();
        }
        public async Task<IActionResult> BuscarPorId(int id)
        {
            if(ModelState.IsValid)
            {
                return View(await _proprietarios.BuscarPorId(id));
            }
            return RedirectToAction("Index");
        }
        [HttpGet("Proprietarios/AdicionarProprietario")]
        public async Task<IActionResult> AdicionarView()
        {
            var visitantes = await _contex.Visitantes.ToListAsync();
            ViewBag.Visitantes = new SelectList(visitantes, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Adicionar(Proprietarios proprietarios)
        {
            if(ModelState.IsValid)
            {
                var user = _sessionUsuary.BuscarSessao();
                if (user.Admin == true)
                {
                    proprietarios.Visitantes = await _contex.Visitantes.Where(a => proprietarios.VisitantesSelecionados!.Contains(a.Id)).ToListAsync();
                    await _proprietarios.AdicionarProprietario(proprietarios);
                    var visitantes = await _contex.Visitantes.ToListAsync();
                    ViewBag.Visitantes = new SelectList(visitantes, "Id", "Name");
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Alterar(int id)
        {
            var _Proprietario = await _contex.Proprietarios.Include(a => a.Visitantes).FirstOrDefaultAsync(a => a.Id == id);
            var visitantes = await _contex.Visitantes.ToListAsync();
            var visitantesselecionados = await _contex.Visitantes.Where(a=>_Proprietario!.VisitantesSelecionados!
            .Contains(id))
            .ToListAsync();
            _Proprietario!.VisitantesSelecionados = _Proprietario?.Visitantes!.Select(a=>a.Id).ToList();
            ViewBag.Visitantes = new SelectList(visitantes, "Id", "Name", visitantesselecionados);
            return View(_Proprietario);
        }
        
            public async Task<IActionResult> Update(int id, Proprietarios Proprietario)
            {
                var propri = await _contex.Proprietarios.Include(a=>a.Visitantes).FirstOrDefaultAsync(a=>a.Id == id);
                propri!.Visitantes = await _contex.Visitantes.Where(a => Proprietario.VisitantesSelecionados!.Contains(a.Id)).ToListAsync();
                
                propri.Sala = Proprietario.Sala;
                propri.Name = Proprietario.Name;
                propri.Documento = Proprietario.Documento;
                propri.VisitantesSelecionados = Proprietario.VisitantesSelecionados;

            
                _contex.Proprietarios.Update(propri);
                await _contex.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
        public async Task<IActionResult> Deletar(int id)
        {
            var _Proprietario = await _contex.Proprietarios.Include(a=>a.Visitantes).FirstOrDefaultAsync(a=>a.Id==id);
            if (_Proprietario == null)
            {
                return RedirectToAction("Index");
            }
            _contex.Proprietarios.Remove(_Proprietario);
            await _contex.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
