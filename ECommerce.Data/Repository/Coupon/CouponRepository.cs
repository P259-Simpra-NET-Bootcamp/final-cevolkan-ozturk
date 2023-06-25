using ECommerce.Data.Context;
using ECommerce.Data;

namespace ECommerce.Data.Repository
{
    public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(ECommerceEfDbContext context) : base(context)
        {

        }

        public IEnumerable<Coupon> FindByCouponCode(string CouponCode)
        {
            var list = dbContext.Set<Coupon>().Where(c => c.CouponCode==CouponCode).ToList();
            return list;
        }

        public List<Coupon> FindByUserId(int UserId)
        {
            return dbContext.Set<Coupon>().Where(c => c.UserId == UserId).ToList();
        }
      
    }
}
