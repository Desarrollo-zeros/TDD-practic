using Domain.Contract;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PersonService : IPersonService
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
            return Persons.FirstOrDefault(x => x.Id == id);
        }

        public List<C> GetAll<C>(string key = "", string opera = "=", string value = "") where C : class
        {
            if (Persons.Count == 0)
                throw new Exception("No hay datos para consultar");
            var list = new List<C>();

            if (typeof(C).Name == "Persons")
            {
                foreach (var persons in Persons)
                {
                    if (Persons is C personsC)
                    {
                        list.Add(personsC);
                    }
                }
                return list;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(key)
                         && string.IsNullOrWhiteSpace(opera) &&
                         string.IsNullOrWhiteSpace(value))
                {

                    if (typeof(Person).GetProperty(key) == null)
                    {
                        throw new Exception("La propieda a consultar no existe");
                    }
                    var keyValues = Persons.Select(person =>
                    {
                        var property = Persons.GetType().GetProperty(key);
                        if (property != null)
                        {
                            return property.GetValue(person);
                        }
                        return null; // O puedes devolver un valor predeterminado en caso de que la propiedad no exista
                    }).ToList();

                    foreach (var keys in keyValues)
                    {
                        if (keys is C keyC)
                        {
                            list.Add(keyC);
                        }
                    }
                }
            }
            return list;
        }

        public bool Update(int id, Person entity)
        {
            if (id == 0 || entity == null) return false;
            if (entity.UserId == 0) return false;
            var index = Persons.FindIndex(x => x.Id == id);
            if (index == -1) return false;
            Persons[index].FirstName = entity.FirstName;
            Persons[index].LastName = entity.LastName;
            Persons[index].Update();
            return true;
        }
    }
}
