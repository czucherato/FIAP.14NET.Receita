using System;
using System.Collections.Generic;
using FIAP14NET.Receita.Core.Dominio.Agregadores;
using FIAP14NET.Receita.Core.Dominio.ObjetosDeValor;

namespace FIAP14NET.Receita.Core.Dominio.Entidades
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

        public Guid Id
        {
            get; set;
        }

        public string Descricao
        {
            get; set;
        }

        public string ModoDePreparo
        {
            get; set;
        }

        public DateTime CriadoEm
        {
            get; set;
        }

        public DateTime AlteradoEm
        {
            get; set;
        }

        public Status Status
        {
            get; set;
        }

        public string Ingredientes
        {
            get; set;
        }
        
        //public IEnumerable<IngredienteReceita> Ingredientes { get; set; } = new List<IngredienteReceita>();
    }
}
