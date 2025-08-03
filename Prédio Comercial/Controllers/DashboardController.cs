using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.ActionFilter;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    [PaginaParaUsuarioAdmin]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public DashboardController(ApplicationDbContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var acessos = await _Context.Acessos.Include(a => a.Visitante).Include(b=>b.Usuarios).ToListAsync();
            acessos.Select(a => a.Usuarios.Login).ToList();
            acessos.Select(b=>b.Visitante.Name).ToList();
            ViewData["ItemCount"] = acessos.Count();
            return View(acessos);
        }
        public async Task<IActionResult> Logger(DateTime date)
        {
            var filter = await _Context.LogsMensage.Where(a=>a.CreatedAt == date.Date).ToListAsync();
            //var Logger = await _Context.LogsMensage.Include(a=>a.Usuarios).Where(a=>a.Usuarios!= null).ToListAsync();
            await _Context.LogsMensage.Select(a => a.Usuarios).ToListAsync();
            var mapperLoger = _Mapper.Map<List<LogAuditoria>>(filter);
            ViewData["Data"] = date.Date.ToString("dd/MM/YYYY");
            return View(mapperLoger);
        }
    }
}
