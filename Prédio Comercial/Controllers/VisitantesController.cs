using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.ActionFilter;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Repository;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    public class VisitantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsuarios _usuarios;
        private readonly ISessionUsuary _sessionUsuary;
        public readonly ILoggerService _loggerService;
        public VisitantesController(ApplicationDbContext applicationDbContext, IUsuarios usuarios, ISessionUsuary sessionUsuary, ILoggerService loggerService)
        {
            _context = applicationDbContext;
            _usuarios = usuarios;
            _sessionUsuary = sessionUsuary;
            _loggerService = loggerService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaVisitantes(string? documento, DateTime dateTime, int id)
        {
            if (!string.IsNullOrEmpty(documento))
            {
                var lista = await _context.Visitantes.Where(x=>x.Documento!.Contains(documento)).ToListAsync();
                return View(lista);
            }
            if (dateTime.Day > 1)
            {
                var listaData = await _context.Visitantes.Where(a=>a.Dataentrada.Day == dateTime.Day).ToListAsync();
                return View(listaData);
            }
            var visitante = await _context.Visitantes.Where(a=>a.Dataentrada<DateTime.Now && a.DataSaida == null).ToListAsync();
            foreach(var a in visitante)
            {
                if(a.Dataentrada < DateTime.Now)
                {
                    ViewBag.Mensagem = $"Ainda não foi dado saída no visitante {a.Name} que entrou na data: {a.Dataentrada}";
                }
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
                await _loggerService.MessagemLog($"Visitante: {visitantes.Name} Cadastrado com sucesso");
                _sessionUsuary.BuscarSessao();
                _context.Visitantes.Add(visitantes);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListaVisitantes");
            }
            await _loggerService.MessagemLog($"Visitante: {visitantes.Name} NÃO FOI CADASTRADO");
            return BadRequest("Nâo foi possível cadastrar o novo visitante");
        }
        public async Task<IActionResult> BuscarPorId(int? id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            return View(visitante);
        }
        public async Task<IActionResult> Detalhes(int? id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            var visianteexpirador = visitante.Dataentrada.AddDays(1);
            if (visianteexpirador > visitante.Dataentrada)
            {
                 ViewBag.Mensagem = $"Ainda não foi dado saída para o visitante {visitante.Name} que entrou dia {visitante.Dataentrada}";
                return View(visitante);
            }
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
                await _loggerService.MessagemLog($"Visitante Atualizado: {visitantes.Name}");
                _context.Visitantes.Update(visitantes);
                await _context.SaveChangesAsync();
                return Ok();
            }
            await _loggerService.MessagemLog($"Visitante não foi Atualizado: {visitantes.Name}");
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
        [PaginaParaUsuarioAdmin]
        public async Task<IActionResult> DeletarVisitante(int? id, Usuarios usuarios)
        {
            if (id == null) return BadRequest();

            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null) return NotFound();
            var UsuarioLogado = _sessionUsuary.BuscarSessao();
            if (UsuarioLogado.Admin == true)
            {
                await _loggerService.MessagemLog($"Visitante: {visitante.Name} deletado com sucesso");
                _context.Visitantes.Remove(visitante);
                await _context.SaveChangesAsync();

                return Ok();
            }
            await _loggerService.MessagemLog($"Visitante: {visitante.Name} não pode ser deletado");
            return BadRequest("Opção disponível apenas para Administradores");
        }
    }
}
