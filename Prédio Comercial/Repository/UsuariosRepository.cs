using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Interface;
using Prédio_Comercial.Models;
using Prédio_Comercial.Service;

namespace Prédio_Comercial.Repository
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly ApplicationDbContext _context;
        public UsuariosRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Usuarios> BuscarPorId(int id)
        {
            var usuarioId = await _context.Usuarios.FindAsync(id);
            return usuarioId;
        }

        public async Task<List<Usuarios>> BuscarTodos()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuarios> Criar(Usuarios usuarios)
        {
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();
            return usuarios;
        }

        public async Task<Usuarios> Deletar(int id, Usuarios usuarios)
        {
            await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return usuarios;
        }

        public async Task<Usuarios> Detalhes(int id)
        {
            var buscarporid = await _context.Usuarios.FindAsync(id);
            return buscarporid;
        }

        public async Task<Usuarios> Editar(int id, Usuarios usuarios)
        {
            var buscarPorId = await _context.Usuarios.FindAsync(id);
            usuarios.Id = buscarPorId.Id;
            usuarios.Admin = buscarPorId.Admin;
            usuarios.DataContratacao = buscarPorId.DataContratacao;
            usuarios.Password = buscarPorId.Password;
            usuarios.Login = buscarPorId.Login;
             _context.Usuarios.Update(usuarios);
            await _context.SaveChangesAsync();
            return usuarios;
            
        }
    }
}
