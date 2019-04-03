using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entidades = FIAP14NET.Receita.Site.Dominio.Entidades;

namespace FIAP14NET.Receita.Site.Persistencia.Mapeamentos
{
    public class ReceitaMap : IEntityTypeConfiguration<Entidades.Receita>
    {
        public void Configure(EntityTypeBuilder<Entidades.Receita> builder) { }
    }
}
