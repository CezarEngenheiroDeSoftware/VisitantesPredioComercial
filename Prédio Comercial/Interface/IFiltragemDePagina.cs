using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Prédio_Comercial.Models;

namespace Prédio_Comercial.Interface
{
    public interface IFiltragemDePagina
    {
        Usuarios Buscar();

    }
}
