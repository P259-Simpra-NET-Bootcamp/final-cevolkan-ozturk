using ECommerce.Data.Context;
using ECommerce.Data;


namespace ECommerce.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceEfDbContext context) : base(context)
        {

        }

        public IEnumerable<Category> FindByName(string name)
        {
            var list = dbContext.Set<Category>().Where(c => c.Name.Contains(name)).ToList();
            return list;
        }

        public int GetAllCount()
        {
            return dbContext.Set<Category>().Count();
        }
    }
}
