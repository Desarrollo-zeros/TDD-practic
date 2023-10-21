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
        public List<Person> Persons;

        public PersonService()
        {
            Persons = new List<Person>();
        }

        public PersonService(List<Person> persons)
        {
            Persons = persons;
        }

        private int GetLastId()
        {
            return (Persons.LastOrDefault()?.Id ?? 0) + 1;
        }

        public int Create(Person entity)
        {
            if (entity == null ||
                string.IsNullOrWhiteSpace(entity.Document)) return 0;
            if (!Persons.Any(x => x.Document == entity.Document))
            {
                entity.Id = GetLastId();
                entity.Create();
                Persons.Add(entity);
                return entity.Id;
            }
            return 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person? Get(int id)
        {
            if (id == 0 || Persons.Count == 0) return null;
            var person = Persons.FirstOrDefault(x => x.Id == id);
            return person;
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
