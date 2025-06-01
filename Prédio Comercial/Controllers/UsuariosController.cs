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
        private readonly ISessionUsuary _sessionUsuary;
        public UsuariosController(IUsuarios usuarios, ISessionUsuary sessionUsuary)
        {
            _usuarios = usuarios;
            _sessionUsuary = sessionUsuary;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> LayoutNovoTeste()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuarios usuarios)
        {
            var login = await _usuarios.Login(usuarios);
            if(login == null)
            {
                TempData["MensageErro"] = $"Login ou Senha incorreto";
                return View(usuarios);
            }
            _sessionUsuary.RemoverSessao();
             _sessionUsuary.CriarSessao(login);
            return RedirectToAction("Index", "Visitantes");

        }
        public async Task<IActionResult> Index()
        {
                
                return View();
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
            //var usuarioLogado = _sessionUsuary.BuscarSessao();
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
