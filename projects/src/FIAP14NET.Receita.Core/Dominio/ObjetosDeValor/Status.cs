using System.ComponentModel.DataAnnotations;

namespace FIAP14NET.Receita.Core.Dominio.ObjetosDeValor
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
