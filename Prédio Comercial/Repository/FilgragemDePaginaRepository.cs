using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;

namespace Prédio_Comercial.Repository
{
    public class FilgragemDePaginaRepository : IFiltragemDePagina
    {
        private readonly ISessionUsuary _sessionUsuary;
        public FilgragemDePaginaRepository(ISessionUsuary sessionUsuary)
        {
            _sessionUsuary = sessionUsuary;
        }
        public Usuarios Buscar()
        {
            Usuarios _CatchUser = _sessionUsuary.BuscarSessao();
            if(_CatchUser != null)
            {
               return _CatchUser;

            }
            return null;
        }

    }
}
