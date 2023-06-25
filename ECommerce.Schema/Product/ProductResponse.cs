using ECommerce.Base;

namespace ECommerce.Schema;

public class ProductResponse : BaseResponse
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Tag { get; set; }
    public int Stock { get; set; }

    public decimal Price { get; set; }

    public string Properties { get; set; }

    public string Description { get; set; }

    public int IsActive { get; set; }

    public decimal PercentageOfPoints { get; set; }

    public decimal MaxPointAmount { get; set; }

    public decimal PointBalance { get; set; }
}
