using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;

namespace Prédio_Comercial.ActionFilter
{
    public class PaginaParaUsuarioAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            {
                string _VerifyUser = context.HttpContext.Session.GetString("UsuarioLogado");
                if (String.IsNullOrEmpty(_VerifyUser))
                {
                    context.Result = new RedirectResult("/Usuarios/Index");
                }
                Usuarios usuarios = JsonConvert.DeserializeObject<Usuarios>(_VerifyUser);
                if (usuarios == null) 
                {
                    context.Result = new RedirectResult("/Usuarios/Index");

                }
                if (usuarios.Admin != true)
                {
                    context.Result = new RedirectResult("/Usuarios/Index");
                }
            }
            base.OnActionExecuting(context);
        }
       
    }
}
