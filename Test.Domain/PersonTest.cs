using Domain.Contract;
using Domain.Entity;
using Domain.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    [TestFixture]
    public class PersonTest
    {
        private IPersonService _personService;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void DeleteSuccesWithData()
        {
            var people = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    FirstName = "Juan",
                    SecondName = "David",
                    LastName = "Castilla",
                    SecondLastName = "García",
                    Document = "1066874827",
                    UserId = 1,
                    User = new User()
                }
            };

            _personService = new PersonService(people);
            var result = _personService.Delete(1);
            var resultResult = _personService.Get(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.IsNull(resultResult);
        }

        [Test]
        public void DeleteFailWithNotData()
        {
            _personService = new PersonService();
            var result = _personService.Delete(2);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFailWithData()
        {
            var people = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    FirstName = "Juan",
                    SecondName = "David",
                    LastName = "Castilla",
                    SecondLastName = "García",
                    Document = "1066874827",
                    UserId = 1,
                    User = new User()
                }
            };
            _personService = new PersonService(people);
            var result = _personService.Delete(2);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}
