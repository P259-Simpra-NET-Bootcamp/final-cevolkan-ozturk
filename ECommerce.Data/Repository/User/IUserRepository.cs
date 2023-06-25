using ECommerce.Data.Repository;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> FindByName(string name);
        int GetAllCount();
    }
}
