using ECommerce.Base;

namespace ECommerce.Schema;

public class OrderRequest : BaseRequest
{
    public int OrderId;
    public int UserId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public decimal BasketAmount { get; set; }
    public decimal CouponAmount { get; set; } = decimal.Zero;
    public string CouponCode { get; set; }
    public decimal PointAmount { get; set; } = decimal.Zero;
    public List<OrderDetailRequest> orderDetailRequests { get; set; }
}
