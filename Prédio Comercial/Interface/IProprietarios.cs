using Microsoft.AspNetCore.Mvc;
using Prédio_Comercial.Models;

namespace Prédio_Comercial.Interface
{
    public interface IProprietarios
    {
       Task<List<Proprietarios>> BuscarTodosProprietarios();
        Task<Proprietarios> BuscarPorId(int id);
        Task<Proprietarios> AdicionarProprietario(Proprietarios proprietario);
        Task<Proprietarios> RemoverProprietario(int id, Proprietarios proprietarios);
        Task<Proprietarios> AtualizarCadastroProrietarios(int id, Proprietarios proprietarios);
    }
}
