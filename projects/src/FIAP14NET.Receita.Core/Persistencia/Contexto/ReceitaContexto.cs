using FIAP14NET.Receita.Core.Persistencia.Contexto.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Entidades = FIAP14NET.Receita.Core.Dominio.Entidades;

namespace FIAP14NET.Receita.Core.Persistencia.Contexto
{
    public class ReceitaContexto : DbContext
    {
        //public ReceitaContexto(DbContextOptions<ReceitaContexto> options)
        //        : base(options)
        //{
        //}

        public DbSet<Entidades.Receita> Receita
        {
            get; set;
        }

        //public DbSet<Entidades.Ingrediente> Ingrediente
        //{
        //    get; set;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Receita;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceitaMap());
            //modelBuilder.ApplyConfiguration(new IngredienteMap());
            //modelBuilder.ApplyConfiguration(new IngredienteReceitaMap());
        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified))
            {
                entry.Property("AlteradoEm").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}
