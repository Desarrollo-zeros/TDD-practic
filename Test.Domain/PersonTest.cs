using AutoFixture;
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
        public void PersonServiceUpdateFailWhenPersonIsNull() 
        {
            //Arrange
            _personService = new PersonService();
            //Act
            var result = _personService.Update(1, null);
         //Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void UpdateUserFail2()
        {

            _personService = new PersonService();
            var result = _personService.Update(1, new Person { });
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateUserFail3()
        {

            _personService = new PersonService();
            var result = _personService.Update(0, new Person { });
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateUserFail4()
        {

            _personService = new PersonService();
            var result = _personService.Update(0, null);
            Assert.IsFalse(result);
        }


        [Test]
        public void CreatePersonFail()
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

        public void UpdateUserSuccess()
        {
            var persons = new List<Person>
            {
                new Person()
                {

                UserId = 1,
                CreatedAt = DateTime.Now,
                Document = "1010121831",
                DocumentType = DocumentType.CC,
                FirstName = "Eduardo",
                LastName = "Zequeira",
                UpdatedAt = DateTime.Now

                }
            };
            _personService = new PersonService(persons);
            var person = new Person()
            {
                UserId = 1,
                CreatedAt = DateTime.Now,
                Document = "1010121831",
                DocumentType = DocumentType.CC,
                FirstName = "Eduardo",
                LastName = "Zequeira",
                UpdatedAt = DateTime.Now
            };
            var result = _personService.Update(1, person);
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateUserSuccess2()
        {
            var persons = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Document = "1010121831",
                    DocumentType = DocumentType.CC,
                    FirstName = "Eduardo",
                    LastName = "Zequeira",
                    UpdatedAt = DateTime.Now
                }
            };
            _personService = new PersonService(persons);
            var person = new Person()
            {
                Id = 1,
                UserId = 1,
                CreatedAt = DateTime.Now,
                Document = "1010121831",
                DocumentType = DocumentType.CC,
                FirstName = "Eduardo",
                LastName = "Zequeira",
                UpdatedAt = DateTime.Now
            };
            var result = _personService.Update(1, person);
            Assert.IsTrue(result);
            var resultPerson = _personService.Get(1);
            Assert.IsNotNull(resultPerson);
            Assert.AreEqual("Eduardo", resultPerson.FirstName);
            Assert.AreEqual("1010121831", resultPerson.Document);
        }

        [Test]
        public void UpdateUserSuccess3()
        {
            var persons = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    UserId = 1,
                    Document = "1010121831",
                    DocumentType = DocumentType.CC,
                    FirstName = "Eduardo",
                    LastName = "Zequeira",
                }
            };
            _personService = new PersonService(persons);
            var person = new Person()
            {
                Id = 1,
                UserId = 1,
                Document = "1010121831",
                DocumentType = DocumentType.CC,
                FirstName = "Eduardo",
                LastName = "Zequeira",
            };
            var result = _personService.Update(1, person);
            var resultUser = _personService.Get(1);
            Assert.IsNotNull(resultUser);
            Assert.IsNull(resultUser?.CreatedAt);
            Assert.IsNotNull(resultUser?.UpdatedAt);
        }


        [Test]

        public void UpdateUserFail5()
        {
            _personService = new PersonService();

            var person = new Person()
            {
                UserId = 1,
                CreatedAt = DateTime.Now,
                Document = "1010121831",
                DocumentType = DocumentType.CC,
                FirstName = "Eduardo",
                LastName = "Zequeira",
                UpdatedAt = DateTime.Now
            };

            var result = _personService.Update(1, person);
            Assert.IsFalse(result);
        }

        public void CreateUserSuccess()
        {
            _personService = new PersonService();
            var person = new Person()
            {
                FirstName = "Oljer",
                LastName = "Murgas",
                SecondName = null,
                SecondLastName = "Castañeda",
                Document = "77177",
                DocumentType = DocumentType.CC,
            };
            var result = _personService.Create(person);
            Assert.AreEqual(1, result);
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