using AutoFixture;
using Domain.Entity;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Test.Infrastructure
{
    [TestFixture]
    public class TestInfrastruture
    {
        private AppDbContext _appDbContext;
        
        private IEnumerable<User> _users;
        [SetUp]
        public void Setup()
        {
        }

        private void Inicializador()
        {
            // Configura una base de datos en memoria
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Crea un contexto de base de datos utilizando la base de datos en memoria
            _appDbContext = new AppDbContext(options);

        }

        private void Seeder()
        {
            Inicializador();
            // Agrega datos
            var fixture = new Fixture();
            _users = fixture.CreateMany<User>(100);
            _appDbContext.Users.AddRange(_users);
            _appDbContext.SaveChanges();

        }

        [Test]
        public void TestGetCountSucccess()
        {
           Seeder();
           var count = _appDbContext.Users.Count();
           Assert.AreEqual(100,count);
        }


        [Test]
        public void TestGetUsernaNameFirstUserSuccess()
        {
            Seeder();
            var username = _appDbContext.Users
                .Select(x => x.UserName)
                .FirstOrDefault();

            var userNameList = _users
                .Select(x => x.UserName)
                .FirstOrDefault();

            Assert.AreEqual(username, userNameList);
        }

        [Test]
        public void TestGetUserAllContentLikeA()
        {
           Seeder();
           var list = _appDbContext
                .Users
                .Where(x => x.UserName
                .ToUpper()
                .Contains("A"));
 
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(list));
            Assert.AreEqual(list.Count(), 100);
        }
    }
}