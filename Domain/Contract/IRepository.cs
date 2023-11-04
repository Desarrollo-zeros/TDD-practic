using Domain.Asbtract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IRepository<T> where T : BaseEntity, IEntity
    {
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void AddRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
        IQueryable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        
    }
}
