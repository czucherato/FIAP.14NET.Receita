using Microsoft.EntityFrameworkCore;
using FIAP14NET.Receita.Core.Dominio.Entidades;
using FIAP14NET.Receita.Core.Dominio.ObjetosDeValor;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIAP14NET.Receita.Core.Persistencia.Contexto.Mapeamentos
{
    public class IngredienteMap : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Unidade)
                .HasConversion(new EnumToStringConverter<Unidade>())
                .HasColumnType("varchar(50)");

            builder.Property(x => x.CriadoEm)
                .HasColumnType("datetime");

            builder.Property(x => x.AlteradoEm)
                .HasColumnType("datetime");

            builder.Property(x => x.Status)
                .HasConversion(new EnumToStringConverter<Status>())
                .HasColumnType("varchar(50)");
        }
    }
}
