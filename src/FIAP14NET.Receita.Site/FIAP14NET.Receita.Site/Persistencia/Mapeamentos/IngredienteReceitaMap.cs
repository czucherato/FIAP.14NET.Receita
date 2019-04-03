using Microsoft.EntityFrameworkCore;
using FIAP14NET.Receita.Site.Dominio.Agregadores;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP14NET.Receita.Site.Persistencia.Mapeamentos
{
    public class IngredienteReceitaMap : IEntityTypeConfiguration<IngredienteReceita>
    {
        public void Configure(EntityTypeBuilder<IngredienteReceita> builder)
        {
            builder.HasKey(x => new { x.IngredienteId, x.ReceitaId });

            builder.Property(x => x.Quantidade);

            builder.HasOne(x => x.Ingrediente)
                .WithMany(y => y.IngredienteReceita)
                .HasForeignKey(x => x.IngredienteId);

            builder.HasOne(x => x.Receita)
                .WithMany(y => y.IngredienteReceita)
                .HasForeignKey(x => x.ReceitaId);
        }
    }
}
