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
    public class ProductController : ControllerBase
    {
        private IProductRepository repository;
        private IMapper mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ResponseCache(Duration = 2000, Location = ResponseCacheLocation.Any, NoStore = false)]
        public List<ProductResponse> GetAll()
        {
            var list = repository.GetAll();
            var mapped = mapper.Map<List<ProductResponse>>(list);
            return mapped;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ProductResponse Post([FromBody] ProductRequest request)
        {
            var entity = mapper.Map<Product>(request);
            repository.Insert(entity);
            repository.Complete();

            var mapped = mapper.Map<Product, ProductResponse>(entity);
            return mapped;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public void Put(int id, [FromBody] ProductRequest request)
        {
            request.Id = id;
            var entity = mapper.Map<Product>(request);
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
