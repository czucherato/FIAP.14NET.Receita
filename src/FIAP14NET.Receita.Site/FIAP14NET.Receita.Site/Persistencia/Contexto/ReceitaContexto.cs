using Microsoft.EntityFrameworkCore;
using FIAP14NET.Receita.Site.Persistencia.Mapeamentos;
using Entidades = FIAP14NET.Receita.Site.Dominio.Entidades;

namespace FIAP14NET.Receita.Site.Persistencia.Contexto
{
    public class ReceitaContexto : DbContext
    {
        public DbSet<Entidades.Receita> Receita { get; set; }

        public DbSet<Entidades.Ingrediente> Ingrediente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Receita;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceitaMap());
            modelBuilder.ApplyConfiguration(new IngredienteMap());
            modelBuilder.ApplyConfiguration(new IngredienteReceitaMap());
        }
    }
}
