﻿using Microsoft.EntityFrameworkCore;
using Prédio_Comercial.Models;

namespace Prédio_Comercial.Service
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Visitantes> Visitantes { get; set; }
    }
}
