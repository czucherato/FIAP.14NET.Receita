using System;
using FIAP14NET.Receita.Site.Dominio.Agregadores;
using FIAP14NET.Receita.Site.Persistencia.Contexto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades = FIAP14NET.Receita.Site.Dominio.Entidades;

namespace FIAP14NET.Receita.Teste.Peristencia.Repositorio
{
    [TestClass]
    public class ReceitaRepTeste
    {
        [TestMethod]
        public void Inserir()
        {
            using (var ctx = new ReceitaContexto())
            {
                Entidades.Receita receita = new Entidades.Receita("Bolo de cenoura", "Acrescentar ingredientes");

                ctx.Receita.Add(receita);
                ctx.SaveChanges();
            }
        }

        [TestMethod]
        public void Inserir_Receita_Ingredientes()
        {
            using (var ctx = new ReceitaContexto())
            {
                Entidades.Ingrediente ingrediente = ctx.Ingrediente.Find(new Guid("78C77BFA-2480-40B8-880C-04AFA83D68B9"));
                Entidades.Receita receita = new Entidades.Receita("Bolo de laranja", "Acrescentar ingredientes");
                receita.IngredienteReceita.Add(new IngredienteReceita(ingrediente, receita, 100));

                ctx.Receita.Add(receita);
                ctx.SaveChanges();
            }
        }
    }
}
