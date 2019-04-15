using FIAP14NET.Receita.Core.Dominio.Agregadores;
using FIAP14NET.Receita.Core.Dominio.ObjetosDeValor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIAP14NET.Receita.Core.Dominio.ViewModels
{
    public class ReceitaViewModel
    {
        public Guid Id
        {
            get; set;
        }

        [Display(Name = "Descrição")]
        public string Descricao
        {
            get; set;
        }

        [Display(Name = "Modo de preparo")]
        public string ModoDePreparo
        {
            get; set;
        }

        [Display(Name = "Criado em")]
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

        public IEnumerable<IngredienteReceita> Ingredientes { get; set; } = new List<IngredienteReceita>();
    }
}
