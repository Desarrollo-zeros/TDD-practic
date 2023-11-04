using AutoFixture;
using Domain.Contract;
using Domain.Entity;
using Infrastructure.Repositories;
using Infrastructure.UniOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Infrastructure.Repositories
{
    public class TestUserRepository
    {
        Init Init;
        UserRepository _userRepository;
        IUnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            Init = new Init();
            _userRepository = new UserRepository(Init.AppDbContext);
            _unitOfWork = new UnitOfWork(Init.AppDbContext);
            
        }

        [Test] 
        public void Create()
        {
            var fixture = new Fixture();
            var users = fixture.CreateMany<User>(2);
            _userRepository.AddRange(users);
            Assert.AreEqual( 2, _unitOfWork.SaveChange());
        }

    }
}
