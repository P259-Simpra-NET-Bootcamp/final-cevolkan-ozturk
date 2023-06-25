using ECommerce.Base;

namespace ECommerce.Schema;

public class UserRequest : BaseRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }

}
