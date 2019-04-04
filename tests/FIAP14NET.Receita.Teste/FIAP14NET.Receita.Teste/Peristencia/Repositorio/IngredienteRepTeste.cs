using FIAP14NET.Receita.Site.Persistencia.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FIAP14NET.Receita.Site.Dominio.ObjetosDeValor;
using Entidades = FIAP14NET.Receita.Site.Dominio.Entidades;

namespace FIAP14NET.Receita.Teste.Peristencia.Repositorio
{
    [TestClass]
    class IngredienteRepTeste
    {
        [TestMethod]
        public void Inserir()
        {
            using (var ctx = new ReceitaContexto())
            {
                Entidades.Ingrediente ingrediente = new Entidades.Ingrediente("Bolo de cenoura", Unidade.Mililitros);

                ctx.Ingrediente.Add(ingrediente);
                ctx.SaveChanges();
            }
        }
    }
}
