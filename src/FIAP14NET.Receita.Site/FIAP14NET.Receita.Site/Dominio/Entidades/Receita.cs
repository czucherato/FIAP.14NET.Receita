using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FIAP14NET.Receita.Site.Dominio.Agregadores;
using FIAP14NET.Receita.Site.Dominio.ObjetosDeValor;

namespace FIAP14NET.Receita.Site.Dominio.Entidades
{
    public class Receita
    {
        protected Receita()
        {
            this.Id = Guid.NewGuid();
            this.Status = Status.Ativo;
            this.CriadoEm = DateTime.Now;
            this.AlteradoEm = DateTime.Now;
        }

        public Receita(string descricao, string modoDePreparo)
            : this()
        {
            this.Descricao = descricao;
            this.ModoDePreparo = modoDePreparo;
        }

        public Guid Id { get; private set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Modo de preparo")]
        public string ModoDePreparo { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CriadoEm { get; set; }

        [Display(Name = "Alterado em")]
        public DateTime AlteradoEm { get; set; }

        public Status Status { get; set; }

        public IList<IngredienteReceita> Ingredientes { get; set; } = new List<IngredienteReceita>();
    }
}
