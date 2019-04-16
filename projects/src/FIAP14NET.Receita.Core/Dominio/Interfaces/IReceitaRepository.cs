using System;
using System.Threading.Tasks;

namespace FIAP14NET.Receita.Core.Dominio.Interfaces
{
    public interface IReceitaRepository : IRepository<Entidades.Receita>
    {
        Entidades.Receita ObterPorId(string id);
        Task<Entidades.Receita> ObterPorIdAssincrono(Guid id);
    }
}
