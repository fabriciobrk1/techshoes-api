
using CadastroUsuarios.Api.Models;
using Microsoft.EntityFrameworkCore;

    namespace CadastroUsuarios.Api.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Usuario> Usuarios { get; set; }
        }
    }
