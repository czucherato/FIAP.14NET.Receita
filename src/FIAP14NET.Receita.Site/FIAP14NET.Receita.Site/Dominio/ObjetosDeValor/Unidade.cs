using System.ComponentModel.DataAnnotations;

namespace FIAP14NET.Receita.Site.Dominio.ObjetosDeValor
{
    public enum Unidade
    {
        [Display(Name = "g")]
        Gramas,
        [Display(Name = "ml")]
        Mililitros
    }
}
