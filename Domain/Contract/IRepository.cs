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
        bool Add(T entity);
        bool Delete(int id);
        bool Update(T entity);
        int AddRange(IEnumerable<T> entities);
        int DeleteRange(List<int> ids);
        IQueryable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>,
           IOrderedQueryable<T>> orderBy = null,
           string includeProperties = ""
        );
        Task<T> GetAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> entities);
        Task<int> DeleteRangeAsync(List<int> ids);
        Task<IQueryable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>,
           IOrderedQueryable<T>> orderBy = null,
           string includeProperties = ""
        );
    }
}
