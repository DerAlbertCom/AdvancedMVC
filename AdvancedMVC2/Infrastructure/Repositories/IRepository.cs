using System;
using System.Linq;
using System.Linq.Expressions;

namespace AdvancedMVC2.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Entities { get; }
        T GetById(int id);
        void Add(T entity);
        void SaveAllChanges();
        void Delete(T entity);
        void Include(Expression<Func<T, object>> expression);
    }
}