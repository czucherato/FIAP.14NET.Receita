using System.ComponentModel.DataAnnotations;

namespace FIAP14NET.Receita.Api.Dominio.ObjetosDeValor
{
    public enum Unidade
    {
        [Display(Name = "g")]
        Gramas,
        [Display(Name = "ml")]
        Mililitros
    }
}
