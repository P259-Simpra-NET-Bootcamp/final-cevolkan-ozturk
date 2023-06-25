using ECommerce.Base;

namespace ECommerce.Schema;

public class TokenRequest : BaseRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
