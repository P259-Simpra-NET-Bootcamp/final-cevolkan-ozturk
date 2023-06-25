using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository
{
    public interface ICouponRepository : IGenericRepository<Coupon>
    {
        IEnumerable<Coupon> FindByCouponCode(string CouponCode);
    
        List<Coupon> FindByUserId(int UserId);   

    }
}
