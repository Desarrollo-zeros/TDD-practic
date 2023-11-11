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
            ////select id from users;
            //_userRepository.GetAll().Select(x => x.Id).ToList();
            ////select * from users where id = 1;
            //_userRepository.GetAll().Where(x => x.Id == 1).ToList();

            ////update users set username = a where id = 1
            //_userRepository.Update(new User
            //{
            //    Id = 1,
            //    UserName = "a"
            //});
            ////insert into users(username) values('a');
            //_userRepository.Add(new User
            //{
            //    UserName = "a"
            //});

            Assert.AreEqual( 2, _unitOfWork.SaveChange());
        }

    }
}
