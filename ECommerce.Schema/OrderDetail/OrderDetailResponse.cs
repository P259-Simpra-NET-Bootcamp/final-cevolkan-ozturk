using ECommerce.Base;

namespace ECommerce.Schema;

public class OrderDetailResponse : BaseResponse
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductAmount { get; set; }
    public decimal ProductTotalAmount { get; set; }
}
