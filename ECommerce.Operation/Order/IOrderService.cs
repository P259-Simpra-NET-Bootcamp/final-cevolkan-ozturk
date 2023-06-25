using ECommerce.Data;
using ECommerce.Domain;
using ECommerce.Schema;

namespace ECommerce.Operation;

public interface IOrderService : IBaseService<Order,OrderRequest, OrderResponse>
{

}
