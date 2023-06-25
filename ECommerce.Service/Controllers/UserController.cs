using AutoMapper;
using ECommerce.Base;
using ECommerce.Data;
using ECommerce.Data.Repository;
using ECommerce.Domain;
using ECommerce.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Service.Controllers
{
    [EnableMiddlewareLogger]
    [ResponseGuid]
    [Route("simapi/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository repository;
        private IMapper mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<UserResponse> GetAll()
        {
            var list = repository.GetAll();
            var mapped = mapper.Map<List<UserResponse>>(list);
            return mapped;
        }

        [HttpPost]
        public UserResponse CreateUser([FromBody] UserRequest request)
        {
            request.Password = CreateMD5(request.Password);

            var entity = mapper.Map<User>(request);
            repository.Insert(entity);
            repository.Complete();

            var mapped = mapper.Map<User, UserResponse>(entity);
            return mapped;
        }

        [HttpPost("admin",Name ="admin")]
        [Authorize(Roles ="admin")]
        public UserResponse CreateAdmin([FromBody] UserRequest request)
        {
            request.Password = CreateMD5(request.Password);

            var entity = mapper.Map<User>(request);
            repository.Insert(entity);
            repository.Complete();

            var mapped = mapper.Map<User, UserResponse>(entity);
            return mapped;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserRequest request)
        {
            var entity = mapper.Map<User>(request);
            repository.Update(entity);
            repository.Complete();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteById(id);
            repository.Complete();
        }

        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes).ToLower();

            }
        }
    }
}
