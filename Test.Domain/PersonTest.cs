using Domain.Contract;
using Domain.Entity;
using Domain.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void GetPersonVoidFailWithNotData()
        {
            _personService = new PersonService();
            var result = _personService.Get(1);
            Assert.IsNull(result);

        }

       

        [Test]
        public void GetPersonVoidFailWithZero()
        {
            _personService = new PersonService();
            var result = _personService.Get(0);
            Assert.IsNull(result);
        }

        [Test]
        public void GetPersonVoidFailWithZeroWithData()
        {
            var persons = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Document = "123456789",
                    DocumentType = DocumentType.CC,
                    FirstName = "tpia",
                    LastName = "",
                    SecondLastName = "",
                    SecondName = "",
                    UpdatedAt = DateTime.Now,
                    User = new User() {},
                    UserId = 1
                  
                }
            };
            _personService = new PersonService(persons);
            var result = _personService.Get(0);
            Assert.IsNull(result);
        }


        [Test]
        public void GetPersonVoidFailWithData()
        {
            var persons = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Document = "123456789",
                    DocumentType = DocumentType.CC,
                    FirstName = "tpia",
                    LastName = "",
                    SecondLastName = "",
                    SecondName = "",
                    UpdatedAt = DateTime.Now,
                    User = new User() {},
                    UserId = 1

                }
            };
            _personService = new PersonService(persons);
            var result = _personService.Get(2);
            Assert.IsNull(result);
        }

        [Test]
        public void GetPersonVoidSuccesslWithData()
        {
            var persons = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Document = "123456789",
                    DocumentType = DocumentType.CC,
                    FirstName = "tpia",
                    LastName = "",
                    SecondLastName = "",
                    SecondName = "",
                    UpdatedAt = DateTime.Now,
                    User = new User() {},
                    UserId = 1

                }
            };
            _personService = new PersonService(persons);
            var result = _personService.Get(1);
            Assert.IsNotNull(result);
            
        }

    }
}
