using BasicClean.Core.Enitties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicClean.Core.Interfaces.Repositories
{
    public interface ICommandRepository<T,TKey> where T: BaseEntity<TKey>
    {
        Task AddAsync(T entity);
        void Add(T entity);
        Task DeleteAsync(TKey id);
        void Delete(TKey id);
        Task UpdateAsync(T entity);
        void Update(T entity);
    }
}
