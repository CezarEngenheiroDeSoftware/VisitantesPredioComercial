using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    public class VisitantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsuarios _usuarios;
        private readonly ISessionUsuary _sessionUsuary;
        public readonly ILogger<VisitantesController> _logger;
        public VisitantesController(ApplicationDbContext applicationDbContext, IUsuarios usuarios, ISessionUsuary sessionUsuary, ILogger<VisitantesController> logger)
        {
            _context = applicationDbContext;
            _usuarios = usuarios;
            _sessionUsuary = sessionUsuary;
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaVisitantes(string documento)
        {
            if (!string.IsNullOrEmpty(documento))
            {
                var lista = _context.Visitantes.Where(x=>x.Documento!.Contains(documento)).ToList();
                return View(lista);
            }
            
            return View(await _context.Visitantes.ToListAsync());
        }
        public IActionResult ListaVisitantesFilter(string documento)
        {
            var Lista = _context.Visitantes!.Where(a=>a.Documento == documento).ToList();
            return View(Lista);
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
                _logger.LogInformation($"Visitante: {visitantes.Name} Cadastrado com sucesso");
                _sessionUsuary.BuscarSessao();
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
        public async Task<IActionResult> DeletarVisitante(int? id, Usuarios usuarios)
        {
            if (id == null) return BadRequest();

            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null) return NotFound();
            var UsuarioLogado = _sessionUsuary.BuscarSessao();
            if (UsuarioLogado.Admin == true)
            {
                _logger.LogInformation($"Visitante: {visitante.Name} deletado com sucesso");
                _context.Visitantes.Remove(visitante);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest("Opção disponível apenas para Administradores");
        }
    }
}
