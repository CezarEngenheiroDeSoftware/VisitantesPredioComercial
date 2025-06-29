using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Models;

namespace Prédio_Comercial.Service
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Visitantes> Visitantes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Acessos> Acessos { get; set; }
        public DbSet<Proprietarios> Proprietarios { get; set;}
        public DbSet<Ocorrencias> Ocorrencias { get; set;}
    }
}
