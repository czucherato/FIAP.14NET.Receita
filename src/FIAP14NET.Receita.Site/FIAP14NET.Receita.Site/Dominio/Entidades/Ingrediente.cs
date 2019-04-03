using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FIAP14NET.Receita.Site.Dominio.Agregadores;
using FIAP14NET.Receita.Site.Dominio.ObjetosDeValor;

namespace FIAP14NET.Receita.Site.Dominio.Entidades
{
    public class Ingrediente
    {
        protected Ingrediente()
        {
            this.Id = Guid.NewGuid();
            this.Status = Status.Ativo;
        }

        public Ingrediente(string nome, Unidade unidade)
            : this()
        {
            this.Nome = nome;
            this.Unidade = unidade;
        }

        public Guid Id { get; protected internal set; }

        public string Nome { get; protected internal set; }

        public Unidade Unidade { get; protected internal set; }

        [Display(Name = "Criado em")]
        public DateTime CriadoEm { get; set; }

        [Display(Name = "Alterado em")]
        public DateTime AlteradoEm { get; set; }

        public Status Status { get; set; }

        public IList<IngredienteReceita> IngredienteReceita { get; set; } = new List<IngredienteReceita>();
    }
}
