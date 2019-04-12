using Microsoft.EntityFrameworkCore;
using FIAP14NET.Receita.Core.Dominio.ObjetosDeValor;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Entidades = FIAP14NET.Receita.Core.Dominio.Entidades;

namespace FIAP14NET.Receita.Core.Persistencia.Contexto.Mapeamentos
{
    public class ReceitaMap : IEntityTypeConfiguration<Entidades.Receita>
    {
        public void Configure(EntityTypeBuilder<Entidades.Receita> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(300)")
                .IsRequired(false);

            builder.Property(x => x.ModoDePreparo)
                .HasColumnType("varchar(3000)")
                .IsRequired(false);

            builder.Property(x => x.CriadoEm)
                .HasColumnType("datetime");

            builder.Property(x => x.AlteradoEm)
                .HasColumnType("datetime");

            builder.Property(x => x.Status)
                .HasConversion(new EnumToStringConverter<Status>())
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }
    }
}
