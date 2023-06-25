using ECommerce.Base;

namespace ECommerce.Schema;

public class TokenResponse : BaseResponse
{
    public DateTime ExpireTime { get; set; }
    public string AccessToken { get; set; }
    public string UserName { get; set; }
}
