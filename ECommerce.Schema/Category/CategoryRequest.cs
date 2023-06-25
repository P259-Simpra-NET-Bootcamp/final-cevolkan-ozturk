using ECommerce.Base;

namespace ECommerce.Schema;

public class CategoryRequest : BaseRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }

    public string Tag { get; set; }
}
