using Prédio_Comercial.Models;

namespace Prédio_Comercial.Interface
{
    public interface IUsuarios
    {
        Task<List<Usuarios>> BuscarTodos();
        Task<Usuarios> BuscarPorId(int id);
        Task<Usuarios> Detalhes(int id);
        Task<Usuarios> Editar(int id, Usuarios usuarios);
        Task<Usuarios> Criar(UsuariosDTO usuarios);
        Task<Usuarios> Deletar(int id, Usuarios usuarios);
        string GerarHash(string texto);
        Task<Usuarios?> Login(Usuarios usuarios);
    }
}
