using Domain.Asbtract;
using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T>
        : IRepository<T> where T : BaseEntity, IEntity
    {

        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(IAppDbContext appDbContext) {
            _dbContext = (AppDbContext)appDbContext;
            _dbSet = _dbContext.Set<T>();
            
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }


        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
           return _dbSet.Where(predicate).ToList();
        }

       
        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }


        public T Get(int id)
        {
            return _dbSet.FirstOrDefault(x => Convert.ToInt32(x.Id) == id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => Convert.ToInt32(x.Id) == id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}
