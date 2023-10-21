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
