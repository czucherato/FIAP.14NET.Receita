using System.ComponentModel.DataAnnotations;

namespace FIAP14NET.Receita.Site.Dominio.ObjetosDeValor
{
    public enum Status
    {
        Indefinido,
        Ativo,
        Inativo,
        [Display(Name = "Excluído")]
        Excluido
    }
}
