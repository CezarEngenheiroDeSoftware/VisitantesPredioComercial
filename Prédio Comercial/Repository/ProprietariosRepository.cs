using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;
using static System.Net.Mime.MediaTypeNames;

namespace Prédio_Comercial.Repository
{
    public class ProprietariosRepository : IProprietarios
    {
        private readonly ApplicationDbContext _context;
        public ProprietariosRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<Proprietarios> AdicionarProprietario(Proprietarios proprietario)
        {
            ////proprietario.visitantes = new List<Visitantes> { };
            await _context.Proprietarios.AddAsync(proprietario);
            await _context.SaveChangesAsync();
            return proprietario;
        }
        public async Task<Proprietarios> BuscarPorId(int id)
        {
            var _Proprietario = await _context.Proprietarios.Include(a=>a.Visitantes).FirstOrDefaultAsync(a=>a.Id == id);
            return _Proprietario;
        }
        public async Task<Proprietarios> AtualizarCadastroProrietarios(int id, Proprietarios proprietarios)
        {
            var PropietarioAtualizado = await _context.Proprietarios.FindAsync(id);
            proprietarios.Name = PropietarioAtualizado.Name;
            proprietarios.Id = PropietarioAtualizado.Id;
            proprietarios.Documento = PropietarioAtualizado.Documento;
            proprietarios.Sala = PropietarioAtualizado.Sala;
            _context.Proprietarios.Update(proprietarios);
            await _context.SaveChangesAsync();
            return proprietarios;

        }

        public async Task<List<Proprietarios>> BuscarTodosProprietarios()
        {
            var teste = await _context.Proprietarios.Include(a => a.Visitantes).ToListAsync();
            if(teste != null)
            {

                return teste;
            }
            return null;
        }

        public async Task<Proprietarios> RemoverProprietario(int id, Proprietarios proprietarios)
        {
            await _context.Proprietarios.FindAsync(id);
            _context.Remove(proprietarios);
            await _context.SaveChangesAsync();
            return proprietarios;
        }
    }
}
