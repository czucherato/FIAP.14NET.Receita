using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIAP14NET.Receita.Core.Dominio.Entidades;
using FIAP14NET.Receita.Core.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FIAP14NET.Receita.Core.Persistencia.Contexto.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        protected ReceitaContexto _context;
        protected DbSet<Dominio.Entidades.Receita> _dbSet;

        public ReceitaRepository(ReceitaContexto context)
        {
            _context = context;
            _dbSet = _context.Set<Dominio.Entidades.Receita>();
        }

        public void Adicionar(Dominio.Entidades.Receita obj)
        {
            _dbSet.Add(obj);
        }

        public void Apagar(Dominio.Entidades.Receita obj)
        {
            _dbSet.Remove(obj);
        }

        public void Editar(Dominio.Entidades.Receita obj)
        {
            _dbSet.Update(obj);
        }

        public Dominio.Entidades.Receita ObterPorId(string id)
        {
            return _dbSet.Find(id);
        }

        public async Task<Dominio.Entidades.Receita> ObterPorIdAssincrono(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<Dominio.Entidades.Receita> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<Dominio.Entidades.Receita>> ObterTodosAssincrono()
        {
            return await _dbSet.ToListAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAssincrono()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
