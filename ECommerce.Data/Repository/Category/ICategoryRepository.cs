using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IEnumerable<Category> FindByName(string name);
        int GetAllCount();
    }
}
