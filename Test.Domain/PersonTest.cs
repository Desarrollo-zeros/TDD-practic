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

        [Test]
        public void CreatePersonFail()
        {
            _personService = new PersonService();
            int result = _personService.Create(null);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CreatePersonFail2()
        {
            _personService = new PersonService();
            int result = _personService.Create(new Person { });
            Assert.AreEqual(0, result);
        }


        [Test]
        public void CreateUserSuccess()
        {
            _personService = new PersonService();
            var person = new Person()
            {
                FirstName = "Oljer",
                LastName = "Murgas",
                SecondName= null,
                SecondLastName="Castañeda",
                Document ="77177",
                DocumentType= DocumentType.CC,
            };
            var result = _personService.Create(person);
            Assert.AreEqual(1, result);
        }
    }
}
