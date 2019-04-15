//using Microsoft.EntityFrameworkCore;
//using FIAP14NET.Receita.Core.Dominio.Agregadores;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace FIAP14NET.Receita.Core.Persistencia.Contexto.Mapeamentos
//{
//    public class IngredienteReceitaMap : IEntityTypeConfiguration<IngredienteReceita>
//    {
//        public void Configure(EntityTypeBuilder<IngredienteReceita> builder)
//        {
//            builder.HasKey(x => new { x.IngredienteId, x.ReceitaId });

//            builder.Property(x => x.Quantidade);

//            builder.HasOne(x => x.Receita)
//                .WithMany(y => y.Ingredientes)
//                .HasForeignKey(x => x.ReceitaId);
//        }
//    }
//}
