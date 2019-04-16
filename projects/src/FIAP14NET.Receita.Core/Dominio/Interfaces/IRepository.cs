using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FIAP14NET.Receita.Core.Dominio.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Editar(TEntity obj);
        void Apagar(TEntity obj);
        int SaveChanges();
        Task<int> SaveChangesAssincrono();
        IEnumerable<TEntity> ObterTodos();
        Task<IEnumerable<TEntity>> ObterTodosAssincrono();

    }
}
