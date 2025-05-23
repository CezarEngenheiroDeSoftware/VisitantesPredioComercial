using Microsoft.AspNetCore.Mvc;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Repository;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarios _usuarios;
        public UsuariosController(IUsuarios usuarios)
        {
            _usuarios = usuarios;
        }
        public async Task<IActionResult> Index()
        {
                var viewUsuario = await _usuarios.BuscarTodos();
                return View(viewUsuario);
        }
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            if (id == 0) { BadRequest();  }
            var usuario = await _usuarios.BuscarPorId(id);
            return View(usuario);
        }
        public async Task<IActionResult> Detalhes(int id)
        {
            Usuarios usuarios = await _usuarios.BuscarPorId(id);
            if(usuarios == null) return NotFound();
            return View(usuarios);
        }
        public async Task<IActionResult> Criar()
        {
            return View();
        }
        public async Task<IActionResult> CriarUsuario(Usuarios usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarios.Password = _usuarios.GerarHash(usuarios.Password);
                    await _usuarios.Criar(usuarios);
                    TempData["MenssageSucesso"] = $"Usuário Criado com Sucesso {usuarios.Login}";
                    return RedirectToAction("Criar");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Nâo foi possível criar usuário");
            }
            TempData["MenssageError"] = $"Não foi possível criar o usuário {usuarios.Login} verifique os dados";
            return RedirectToAction("Criar");
        }

        public async Task<IActionResult> EditarUsuario(int id)
        {
            Usuarios usuarios = await _usuarios.BuscarPorId(id);
            return View(usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarUsuario(int id, Usuarios usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _usuarios.Editar(id, usuarios);
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Não foi possível editar o Usuário");
            }
            return View(usuarios);
        }

        public async Task<IActionResult> Deletar()
        {
            return View();
        }
        public async Task<IActionResult> Deletar(int id, Usuarios usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _usuarios.Deletar(id, usuarios);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Não foi possível deletar o Usuário");
            }
            return RedirectToAction("Index");
        }
    }

}
