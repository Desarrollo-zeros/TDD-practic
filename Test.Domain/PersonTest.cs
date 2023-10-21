﻿using Domain.Contract;
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
<<<<<<< HEAD
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
=======
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
>>>>>>> d1755a12498bb651fff886c00d2981a65e088cd9
        }


        [Test]
<<<<<<< HEAD
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

=======
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
>>>>>>> d1755a12498bb651fff886c00d2981a65e088cd9
    }
}
