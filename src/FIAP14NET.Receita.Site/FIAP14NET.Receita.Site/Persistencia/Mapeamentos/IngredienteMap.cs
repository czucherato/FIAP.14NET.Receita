using Microsoft.EntityFrameworkCore;
using FIAP14NET.Receita.Site.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP14NET.Receita.Site.Persistencia.Mapeamentos
{
    public class IngredienteMap : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder) { }
    }
}
