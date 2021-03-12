using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistence.Config;

namespace Persistence
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :base(options)
        { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Curso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CategoryConfig(modelBuilder.Entity<Categoria>());
            new CursoConfig(modelBuilder.Entity<Curso>());
        }

    }
}
