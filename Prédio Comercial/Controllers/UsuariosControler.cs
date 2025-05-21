using Microsoft.AspNetCore.Mvc;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Repository;

namespace Prédio_Comercial.Controllers
{
    public class UsuariosControler : Controller
    {
        private readonly IUsuarios _usuarios;
        public UsuariosControler(IUsuarios usuarios)
        {
            _usuarios = usuarios;
        }
        public async Task<IActionResult> Index()
        {
                var viewUsuario = await _usuarios.BuscarTodos();
                return RedirectToAction("Index");
        }
    }
}
