using System;

namespace FIAP14NET.Receita.Site.Dominio.Agregadores
{
    public class IngredienteReceita
    {
        protected IngredienteReceita() { }

        public IngredienteReceita(Entidades.Ingrediente ingrediente, Entidades.Receita receita, decimal quantidade)
            : this()
        {
            this.Ingrediente = ingrediente;
            this.Receita = receita;
            this.Quantidade = quantidade;
        }

        private Guid _ingredienteId;
        public Guid IngredienteId
        { 
            get { return this.Ingrediente.Id; }
            protected internal set { _ingredienteId = this.Ingrediente.Id; }
        }

        public Entidades.Ingrediente Ingrediente { get; protected internal set; }

        private Guid _receitaId;
        public Guid ReceitaId
        {
            get { return this.Receita.Id; }
            protected internal set { _receitaId = this.Receita.Id; }
        }

        public Entidades.Receita Receita { get; protected internal set; }

        public decimal Quantidade { get; protected internal set; }
    }
}
