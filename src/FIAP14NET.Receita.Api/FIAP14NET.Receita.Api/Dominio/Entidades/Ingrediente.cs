using System;
using FIAP14NET.Receita.Api.Dominio.ObjetosDeValor;

namespace FIAP14NET.Receita.Api.Dominio.Entidades
{
    public class Ingrediente
    {
        public Ingrediente() => this.Id = new Guid();

        public Ingrediente(string nome, Unidade unidade)
            : this()
        {
            this.Nome = nome;
            this.Unidade = unidade;
        }

        public Guid Id { get; protected internal set; }

        public string Nome { get; protected internal set; }

        public Unidade Unidade { get; protected internal set; }
    }
}
