using ECommerce.Base;

namespace ECommerce.Schema;

public class UserResponse : BaseResponse
{
   
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
    public int Status { get; set; }
    public DateTime LastActivity { get; set; }
    public int PasswordRetryCount { get; set; }
    public decimal PointBalance { get; set; }
}
