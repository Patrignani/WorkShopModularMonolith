using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Domain.Core.Models;

namespace WorkShop.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable 
    {
        void Add(TEntity obj);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity obj);
        Task Remove(Guid id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task SaveChangesAsync();

        Task<bool> CheckExistItem(TEntity obj);
    }
}
