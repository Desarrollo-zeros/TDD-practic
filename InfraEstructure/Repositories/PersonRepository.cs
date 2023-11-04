using Domain.Contract;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(IAppDbContext appDbContext) 
            : base(appDbContext)
        {
        }
    }
}
