using AutoMapper;
using ECommerce.Base;
using ECommerce.Data;
using ECommerce.Data.Repository;
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
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository repository;
        private IMapper mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ResponseCache(Duration = 2000, Location = ResponseCacheLocation.Any, NoStore = false)]
        public List<CategoryResponse> GetAll()
        {
            var list = repository.GetAll();
            var mapped = mapper.Map<List<CategoryResponse>>(list);
            return mapped;
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = ResponseCasheType.Minute45)]
        public CategoryResponse GetById(int id)
        {
            var row = repository.GetById(id);
            var mapped = mapper.Map<CategoryResponse>(row);
            return mapped;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public CategoryResponse Post([FromBody] CategoryRequest request)
        {
            var entity = mapper.Map<Category>(request);
            repository.Insert(entity);
            repository.Complete();

            var mapped = mapper.Map<Category, CategoryResponse>(entity);
            return mapped;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public void Put(int id, [FromBody] CategoryRequest request)
        {
            request.Id = id;
            var entity = mapper.Map<Category>(request);
            repository.Update(entity);
            repository.Complete();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            repository.DeleteById(id);
            repository.Complete();
        }
    }
}
