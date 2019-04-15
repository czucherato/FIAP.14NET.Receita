using FIAP14NET.Receita.Core.Dominio.ObjetosDeValor;
using System;
using System.ComponentModel.DataAnnotations;

namespace FIAP14NET.Receita.Core.Dominio.ViewModels
{
    public class IngredienteViewModel
    {
        public Guid Id
        {
            get; set;
        }

        public string Nome
        {
            get; set;
        }

        public Unidade Unidade
        {
            get; set;
        }

        [Display(Name = "Criado em")]
        public DateTime CriadoEm
        {
            get; set;
        }

        [Display(Name = "Alterado em")]
        public DateTime AlteradoEm
        {
            get; set;
        }

        public Status Status
        {
            get; set;
        }
    }
}
