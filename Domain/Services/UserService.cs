using Domain.Contract;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        public List<User> Users;

        public UserService() { 
            Users = new List<User>();
        }

        public UserService(List<User> users)
        {
            Users = users;
        }

        private int GetLastId()
        {
            return (Users.LastOrDefault()?.Id ?? 0) + 1;
        }

        public int Create(User entity)
        {
            if (entity == null ||
                string.IsNullOrWhiteSpace(entity.Email)) return 0;
            if(!Users.Any(x =>  x.Email == entity.Email))
            {
                entity.Id = GetLastId();
                entity.Create();
                Users.Add(entity);
                return entity.Id;
            }
            return 0;
        }

        public bool Delete(int id)
        {
            if (id == 0 || Users.Count == 0) return false;
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return false;
            return Users.Remove(user);
        }
        public User? Get(int id)
        {
            if (id == 0 || Users.Count == 0) return null;
            var user = Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public List<C> GetAll<C>(string key = "", string opera = "", string value = "") where C : class
        {
            if (Users.Count == 0) 
                throw new Exception("No hay datos para consultar");
            var list = new List<C>();
            
            if(typeof(C).Name == "User")
            {
                foreach (var user in Users)
                {
                    if (user is C userC)
                    {
                        list.Add(userC);
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

                    if(typeof(User).GetProperty(key) == null)
                    {
                        throw new Exception("La propieda a consultar no existe");
                    }
                    var keyValues = Users.Select(user =>
                    {
                        var property = user.GetType().GetProperty(key);
                        if (property != null)
                        {
                            return property.GetValue(user);
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

        public bool Update(int id, User entity)
        {
            if(id  == 0||entity == null) return false;
            if(entity.Email == null) return false;
            var index = Users.FindIndex(x => x.Id == id);
            if(index == -1) return false;
            Users[index].UserName = entity.UserName;
            Users[index].UserName = entity.UserName;
            Users[index].Password = entity.Password;
            Users[index].Active = entity.Active;
            Users[index].Update();
            return true;
        }
    }
}
