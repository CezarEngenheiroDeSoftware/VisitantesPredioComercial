using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.ActionFilter;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    [PaginaParaUsuarioAdmin]
    public class DashBoardDTOController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDashBoardDTO _dashBoardDTO;
        public DashBoardDTOController(ApplicationDbContext applicationDbContext, IDashBoardDTO dashBoardDTO)
        {
            _context = applicationDbContext;
            _dashBoardDTO = dashBoardDTO;
        }
        public async Task<IActionResult> Index(DateTime date)
        {
            if(date.Day > 1)
            {
                var filter = await _dashBoardDTO.GetUserDate(date);
                return View(filter);
            }
            return View( await _dashBoardDTO.GetDashBoardDTO());
        }
    }
}
