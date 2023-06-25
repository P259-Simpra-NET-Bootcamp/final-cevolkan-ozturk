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
    public class CouponController : ControllerBase
    {
        private ICouponRepository repository;
        private IMapper mapper;

        public CouponController(ICouponRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ResponseCache(Duration = 2000, Location = ResponseCacheLocation.Any, NoStore = false)]
        public List<CouponResponse> GetAll()
        {
            var list = repository.GetAll();
            var mapped = mapper.Map<List<CouponResponse>>(list);
            return mapped;
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = ResponseCasheType.Minute45)]
        public CouponResponse GetById(int id)
        {
            var row = repository.GetById(id);
            var mapped = mapper.Map<CouponResponse>(row);
            return mapped;
        }

        [HttpGet("user/{userId}")]
        [ResponseCache(CacheProfileName = ResponseCasheType.Minute45)]
        public List<CouponResponse> GetByUserId(int userId)
        {
            var row = repository.FindByUserId(userId);
            var mapped = mapper.Map<List<CouponResponse>>(row);
            return mapped;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public CouponResponse Post([FromBody] CouponRequest request)
        {
            var entity = mapper.Map<Coupon>(request);
            repository.Insert(entity);
            repository.Complete();

            var mapped = mapper.Map<Coupon, CouponResponse>(entity);
            return mapped;
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
