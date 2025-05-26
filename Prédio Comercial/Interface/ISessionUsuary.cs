using Prédio_Comercial.Models;

namespace Prédio_Comercial.Interface
{
    public interface ISessionUsuary 
    {
        void CriarSessao(Usuarios usuarios);
        void RemoverSessao();
        Usuarios BuscarSessao();
    }
}
