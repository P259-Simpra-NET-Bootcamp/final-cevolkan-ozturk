using ECommerce.Data.Context;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ECommerceEfDbContext context) : base(context)
        {

        }

        public IEnumerable<User> FindByName(string name)
        {
            var list = dbContext.Set<User>().Where(c => c.Name.Contains(name)).ToList();
            return list;
        }

        public int GetAllCount()
        {
            return dbContext.Set<User>().Count();
        }
    }
}
