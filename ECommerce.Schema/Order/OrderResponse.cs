using ECommerce.Base;

namespace ECommerce.Schema;

public class OrderResponse : BaseResponse
{
    public int OrderId;
    public int UserId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    public decimal BasketAmount { get; set; }

    public decimal CouponAmount { get; set; }

    public string CouponCode { get; set; }

    public decimal PointAmount { get; set; }

    public List<OrderDetailResponse> orderDetailResponses { get; set; }
}
