using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prédio_Comercial.Interface;

namespace Prédio_Comercial.ViewsComponents
{
    public class MenuComponent : ViewComponent
    {
        private readonly ISessionUsuary _sessionUsuary;
        public MenuComponent(ISessionUsuary sessionUsuary)
        {
            _sessionUsuary = sessionUsuary;   
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UsuarioLogado = _sessionUsuary.BuscarSessao();
            return View(UsuarioLogado);
        }
    }
}
