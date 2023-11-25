using Domain.Contract;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IRepository<User> repository, 
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;   
        }

        [HttpPost]
        public bool CreateUser([FromBody]User user)
        {
            _repository.Add(user);
            return _unitOfWork.SaveChange()>0;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return _repository.GetAll().ToList();
        }
    }
}