using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UniOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        IAppDbContext _dbContext;
        public UnitOfWork(IAppDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        public int SaveChange()
        {
           return _dbContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }
    }
}
