using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using System.Net.Http;

namespace Prédio_Comercial.Repository
{
    public class SessionRepository : ISessionUsuary
    {
        private readonly IHttpContextAccessor _httpClientAcessor;
        public SessionRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpClientAcessor = httpContextAccessor;
        }
        public Usuarios BuscarSessao()
        {
            string usuariologado = _httpClientAcessor.HttpContext.Session.GetString("UsuarioLogado");
            if(string.IsNullOrEmpty(usuariologado)) { return null; }
            var usuarioLogado = JsonConvert.DeserializeObject<Usuarios>(usuariologado);
            return usuarioLogado;
        }

        public void CriarSessao(Usuarios usuarios)
        {
            string usuarioLogado = JsonConvert.SerializeObject(usuarios);
            _httpClientAcessor.HttpContext.Session.SetString("UsuarioLogado", usuarioLogado);
        }

        public void RemoverSessao()
        {
            _httpClientAcessor.HttpContext.Session.Remove("UsuarioLogado");
        }
    }
}
