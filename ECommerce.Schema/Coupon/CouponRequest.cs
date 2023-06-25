using ECommerce.Base;

namespace ECommerce.Schema;

public class CouponRequest : BaseRequest
{
    public string CouponCode { get; set; }

    public decimal CouponAmount { get; set; }

    public int UserId { get; set; }

    public DateTime? CouponExpireDate { get; set; }

    public int CouponRedemptionStatus { get; set; }
}
