using ECommerce.Data.Context;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Data.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceEfDbContext context) : base(context)
        {

        }
    }
}
