using ECommerce.Data.Context;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Data.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceEfDbContext context) : base(context)
        {

        }

        public IEnumerable<Product> FindByName(string name)
        {
            var list = dbContext.Set<Product>().Where(c => c.Name.Contains(name)).ToList();
            return list;
        }

        public int GetAllCount()
        {
            return dbContext.Set<Product>().Count();
        }
    }
}
