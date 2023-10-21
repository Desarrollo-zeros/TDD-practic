using AutoFixture;
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
        public void GetAllDataFilterFailWithNotData()
        {
            //Arrange
            _personService = new PersonService();

            //Act
            var ex = Assert.Throws<Exception>(
                () => _personService.GetAll<Person>()
            );

            //Assert
            Assert.
                That(ex.Message,
                Is.EqualTo("No hay datos para consultar"));
        }

        [Test]
        public void GetAllDataFilterKeyFailtWithData()
        {
            //Arrange
            var fixture = new Fixture();
            var listPerson = fixture.CreateMany<Person>(10);
            _personService = new PersonService(listPerson.ToList());

            //Act
            var ex = Assert.Throws<Exception>(
               () => _personService.GetAll<string>("name")
           );

            //Assert
            Assert.
                That(ex.Message,
                Is.EqualTo("La propieda a consultar no existe"));
        }

        [Test]
        public void GetAllDataFilterKeySuccessWithData()
        {
            //Arrange
            var fixture = new Fixture();
            var listPerson = fixture.CreateMany<Person>(10);
            _personService = new PersonService(listPerson.ToList());

            //Act
            var person = _personService.GetAll<string>("Document");

            //Assert
            Assert.IsNotNull(person);
            Assert.AreEqual(person.Count, 10);
            Assert.AreEqual(person.FirstOrDefault(),
                listPerson.FirstOrDefault()?.Document);
            Assert.AreEqual(person.LastOrDefault(),
               listPerson.LastOrDefault()?.Document);
        }

        [Test]
        public void GetAllDataFilterSuccessWithData()
        {
            //Arrange
            var fixture = new Fixture();
            var listPerson = fixture.CreateMany<Person>(10);
            _personService = new PersonService(listPerson.ToList());

            //Act
            var person = _personService.GetAll<Person>();

            //Assert
            Assert.IsNotNull(person);
            Assert.AreEqual(person.Count, 10);
        }
    }
}
