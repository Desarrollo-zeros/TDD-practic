using Domain.Contract;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    internal class PersonService : IPersonService
    {
        public int Create(Person entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<C> GetAll<C>(string key = "", string opera = "=", string value = "") where C : class
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
