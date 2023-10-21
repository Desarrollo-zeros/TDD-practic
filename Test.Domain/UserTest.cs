using AutoFixture;
using Domain.Contract;
using Domain.Entity;
using Domain.Services;
using NUnit.Framework;

namespace Test.Domain
{
    [TestFixture]
    public class UserTest
    {
        private IUserService _userService;

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void CreateUserFail()
        {
            _userService = new UserService();
            int result = _userService.Create(null);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CreateUserFail2()
        {
            _userService = new UserService();
            int result = _userService.Create(new User { });
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CreateUserSuccess()
        {
            _userService = new UserService();
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password",
                UserName = "name",
            };
            var result = _userService.Create(user);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void UpdateUserFail()
        {
            
            _userService = new UserService();
            var result = _userService.Update(1, null);
            Assert.IsFalse(result);   
        }

        [Test]
        public void UpdateUserFail2()
        {

            _userService = new UserService();
            var result = _userService.Update(1, new User { });
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateUserFail3()
        {

            _userService = new UserService();
            var result = _userService.Update(0, new User { });
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateUserFail4()
        {

            _userService = new UserService();
            var result = _userService.Update(0, null);
            Assert.IsFalse(result);
        }


        [Test]
        public void UpdateUserFail5() {
            _userService = new UserService();

            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password",
                UserName = "name",
            };

            var result = _userService.Update(1, user);
            Assert.IsFalse(result);
        }


        public void UpdateUserSuccess()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password1",
                UserName = "name1",
            };
            var result = _userService.Update(1, user);
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateUserSuccess2()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password1",
                UserName = "name1",
            };
            var result = _userService.Update(1, user);
            Assert.IsTrue(result);
            var resultUser = _userService.Get(1);
            Assert.IsNotNull(resultUser);
            Assert.AreEqual("name1", resultUser.UserName);
            Assert.AreEqual("password1", resultUser.Password);
        }



        [Test]
        public void UpdateUserSuccess3()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var user = new User()
            {
                Email = "carlos.castilla@devzeros.com",
                Active = true,
                Password = "password1",
                UserName = "name1",
            };
            var result = _userService.Update(1, user);
            var resultUser = _userService.Get(1);
            Assert.IsNotNull(resultUser);
            Assert.IsNull(resultUser?.CreatedAt);
            Assert.IsNotNull(resultUser?.UpdatedAt);
        }


        [Test]
        public void GetUserVoidFailWithNotData()
        {
            _userService = new UserService();
            var result  = _userService.Get(1);
            Assert.IsNull(result);
        }

        [Test]
        public void GetUserVoidFailWithZero()
        {
            _userService = new UserService();
            var result = _userService.Get(0);
            Assert.IsNull(result);
        }

        [Test]
        public void GetUserVoidFailWithZeroWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var result = _userService.Get(0);
            Assert.IsNull(result);
        }


        [Test]
        public void GetUserVoidFailWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var result = _userService.Get(2);
            Assert.IsNull(result);
        }

        [Test]
        public void GetUserVoidSuccesslWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var result = _userService.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("carlos.castilla@devzeros.com", result.Email);
            Assert.AreEqual(true, result.Active);
            Assert.AreEqual("password", result.Password);
            Assert.AreEqual("name", result.UserName);
        }


        /*
         *   Funcionalidad:
         *      Realizar el borrado de un usuario cuando
         *      este exista.
         *   Caso 1:
         *      Si el usuario existe, eliminarlo
         *   Caso 2: 
         *      Si el usuario tiene relacionado una persona,
         *      no deberia poder eliminarse*
         *   case 3:
         *      Si existe una configuración global
         *      donde permita elinación en cascada, 
         *      realizar el borrado del usuario sin validar
         *      si tiene relaciones
         *   excepciones:
         *      caso 1:
         *          Si no el existe el usuario, arrojar falso
         *      caso 2:
         *          Si el valor esta amarrado a relación con 
         *          persona, arrojar falso
         *      caso 3:    
         *          
         */
        [Test]
        public void DeleteSuccessWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var result = _userService.Delete(1);
            var resultResult = _userService.Get(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.IsNull(resultResult);
        }

        [Test]
        public void DeleteFailWithNotData()
        {   
            _userService = new UserService();
            var result = _userService.Delete(2);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFailWithData()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "carlos.castilla@devzeros.com",
                    Active = true,
                    Password = "password",
                    UserName = "name",
                }
            };
            _userService = new UserService(users);
            var result = _userService.Delete(2);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }


        //digitat una key y traer todo los datos pero solo la key

        [Test]
        public void GetAllDataFilterFailWithNotData()
        {
            _userService = new UserService();
            var ex =  Assert.Throws<Exception>(
                () => _userService.GetAll<User>()
            );
            Assert.
                That(ex.Message,
                Is.EqualTo("No hay datos para consultar"));
        }

        [Test]
        public void GetAllDataFilterSuccessWithData()
        {
            var fixture = new Fixture();
            var listUsers = fixture.CreateMany<User>(10);
            _userService = new UserService(listUsers.ToList());
            var users = _userService.GetAll<User>();
            Assert.IsNotNull(users);
            Assert.AreEqual(users.Count, 10);
        }

        [Test]
        public void GetAllDataFilterKeyFailtWithData()
        {
            var fixture = new Fixture();
            var listUsers = fixture.CreateMany<User>(10);
            _userService = new UserService(listUsers.ToList());
            
            var ex = Assert.Throws<Exception>(
               () => _userService.GetAll<string>("name")
           );
            Assert.
                That(ex.Message,
                Is.EqualTo("La propieda a consultar no existe"));
        }


        [Test]
        public void GetAllDataFilterKeySuccessWithData()
        {
            var fixture = new Fixture();
            var listUsers = fixture.CreateMany<User>(10);
            _userService = new UserService(listUsers.ToList());

            var users = _userService.GetAll<string>("UserName");
            Assert.IsNotNull(users);
            Assert.AreEqual(users.Count, 10);
            Assert.AreEqual(users.FirstOrDefault(), 
                listUsers.FirstOrDefault()?.UserName);
            Assert.AreEqual(users.LastOrDefault(),
               listUsers.LastOrDefault()?.UserName);
        }

    }
}