using ECommerce.Data;
using ECommerce.Domain;
using ECommerce.Schema;

namespace ECommerce.Operation;

public interface IUserService : IBaseService<User,UserRequest,UserResponse>
{

}
