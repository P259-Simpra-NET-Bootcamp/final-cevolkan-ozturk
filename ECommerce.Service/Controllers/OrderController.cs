using AutoMapper;
using ECommerce.Base;
using ECommerce.Data.Repository;
using ECommerce.Operation;
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
    public class OrderController : ControllerBase
    {
        private IOrderRepository repository;
        private IMapper mapper;
        private IOrderService orderService;

        public OrderController(IOrderService orderService,IOrderRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public List<OrderResponse> GetAll()
        {
            var list = repository.GetAll();
            var mapped = mapper.Map<List<OrderResponse>>(list);
            return mapped;
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = ResponseCasheType.Minute45)]
        public OrderResponse GetById(int id)
        {
            var row = repository.GetById(id);
            var mapped = mapper.Map<OrderResponse>(row);
            return mapped;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] OrderRequest request)
        {
            return orderService.Insert(request);
        }
    }
}
