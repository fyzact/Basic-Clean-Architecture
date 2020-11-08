using BasicClean.Core.Enitties;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BasicClean.Core.Interfaces.Repositories
{
    public interface IQueryRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> match);
        T Get(Expression<Func<T, bool>> match);
    }
}
